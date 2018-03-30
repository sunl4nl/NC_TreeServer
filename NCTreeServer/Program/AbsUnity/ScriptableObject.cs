using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AbsUnity
{
    public class ScriptableObject : Object
    {
        public ScriptableObject()
        {
            ScriptableObject.Internal_CreateScriptableObject(this);
        }

        private static void Internal_CreateScriptableObject(ScriptableObject self)
        {
        }

        [Obsolete("Use EditorUtility.SetDirty instead")]
        public void SetDirty()
        {
            ScriptableObject.INTERNAL_CALL_SetDirty(this);
        }
        private static void INTERNAL_CALL_SetDirty(ScriptableObject self)
        {

        }
        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern ScriptableObject CreateInstance(string className);

        public static ScriptableObject CreateInstance(Type type)
        {
            return ScriptableObject.CreateInstanceFromType(type);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ScriptableObject CreateInstanceFromType(Type type);

        public static T CreateInstance<T>() where T : ScriptableObject
        {
            return (T)((object)ScriptableObject.CreateInstance(typeof(T)));
        }
    }
}
