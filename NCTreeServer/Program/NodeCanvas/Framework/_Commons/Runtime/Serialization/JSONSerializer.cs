#define ABSTRACT_UNITY
using System;
using System.Collections.Generic;
using ParadoxNotion.Serialization.FullSerializer;
using ParadoxNotion.Serialization.FullSerializer.Internal;
#if ABSTRACT_UNITY
using Object = AbsUnity.Object;
#else
using Object = UnityEngine.Object;
#endif

namespace ParadoxNotion.Serialization{

    ///Serializes/Deserializes to/from JSON with 'FullSerializer'
    public static class JSONSerializer {
        
#if UNITY_EDITOR //this is used to avoid calling Unity API in serialization for the editor
        [UnityEditor.InitializeOnLoad]
        class StartUp{
            static StartUp(){
                //set to false since this is always called in editor start where application is not playing.
                JSONSerializer.applicationPlaying = false;
                UnityEditor.EditorApplication.playmodeStateChanged += ()=>
                {
                    JSONSerializer.applicationPlaying = Application.isPlaying && UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode;
                };
            }
        }
#endif

        private static Dictionary<string, fsData> cache = new Dictionary<string, fsData>();
        private static object serializerLock = new object();
        private static fsSerializer serializer = new fsSerializer();
        private static bool init = false;

        //initialize to true since StartUp is editor only and in runtime application is of course always playing.
        public static bool applicationPlaying = true;

        ///Serialize to json
#if !ABSTRACT_UNITY
            public static string Serialize(Type type, object value, bool pretyJson = false, List<UnityEngine.Object> objectReferences = null) 
            {
#else
        public static string Serialize(Type type, object value, bool pretyJson = false, List<Object> objectReferences = null)
        {
#endif
        

            lock (serializerLock)
            {
                if (!init){
                    serializer.AddConverter(new fsUnityObjectConverter());
                    init = true;
                }

                //set the objectReferences context
                if (objectReferences != null){
                    objectReferences.Clear(); //we clear the list since it will be populated by the converter.
#if !ABSTRACT_UNITY
                    serializer.Context.Set<List<UnityEngine.Object>>(objectReferences);
#else
                    serializer.Context.Set<List<Object>>(objectReferences);
#endif
                }

                //serialize the data
                fsData data;
                //We override the UnityObject converter if we serialize a UnityObject directly.
                //UnityObject converter will still be used for every serialized property found within the object though.
#if !ABSTRACT_UNITY
                var overrideConverterType = typeof(UnityEngine.Object).RTIsAssignableFrom(type)? typeof(fsReflectedConverter) : null;
#else
                var overrideConverterType = typeof(Object).RTIsAssignableFrom(type) ? typeof(fsReflectedConverter) : null;
#endif
                serializer.TrySerialize(type, overrideConverterType, value, out data).AssertSuccess();

                //print data to json
                if (pretyJson){
                    return fsJsonPrinter.PrettyJson(data);
                }
                return fsJsonPrinter.CompressedJson(data);
            }
        }

        ///Deserialize generic
        
        public static T Deserialize<T>(string serializedState, List<Object> objectReferences = null, T deserialized = default(T)){
            return (T)Deserialize(typeof(T), serializedState, objectReferences, deserialized);
        }

        ///Deserialize from json
        public static object Deserialize(Type type, string serializedState, List<Object> objectReferences = null, object deserialized = null)
        {
            lock (serializerLock)
            {
                if (!init){
                    serializer.AddConverter(new fsUnityObjectConverter());
                    init = true;
                }

                //set the objectReferences context
                if (objectReferences != null){
                    serializer.Context.Set<List<Object>>(objectReferences);
                }

                fsData data = null;
                cache.TryGetValue(serializedState, out data);
                if (data == null){
                    data = fsJsonParser.Parse(serializedState);
                    var str = data.ToString();
                    cache[serializedState] = data;                
                }

                //deserialize the data
                //We override the UnityObject converter if we deserialize a UnityObject directly.
                //UnityObject converter will still be used for every serialized property found within the object though.
                var overrideConverterType = typeof(Object).RTIsAssignableFrom(type) ? typeof(fsReflectedConverter) : null;
                serializer.TryDeserialize(data, type, overrideConverterType, ref deserialized).AssertSuccess();

                return deserialized;
            }
        }
    }
}