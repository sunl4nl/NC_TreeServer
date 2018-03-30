using System.Collections.Generic;
using System;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace ParadoxNotion.Services {

    ///Singleton. Automatically added when needed, collectively calls methods that needs updating amongst other things relevant to MonoBehaviours
    public class MonoManager : MonoBehaviour {

        public enum UpdateMode{
            Auto,
            Manual
        }

        public static UpdateMode updateMode{
            get {return current.enabled? UpdateMode.Auto : UpdateMode.Manual;}
            set {current.enabled = value == UpdateMode.Auto;}
        }

        //These can be used by the user, or when un/subscribe is not regular.
        public event Action onUpdate;
        public event Action onLateUpdate;
        public event Action onFixedUpdate;
        public event Action onGUI;
        public event Action onApplicationQuit;
        public event Action<bool> onApplicationPause;

        private static bool isQuiting;

        private static MonoManager _current;
        public static MonoManager current {
            get
            {
                if ( _current == null && !isQuiting ) {
                    _current = FindObjectOfType<MonoManager>();
                    if ( _current == null ){
                        _current = new GameObject("_MonoManager").AddComponent<MonoManager>();
                    }
                }
                return _current;
            }
        }


        ///Creates the MonoManager singleton
        public static void Create() { _current = current; }

        void OnApplicationQuit(){
            isQuiting = true;
            if (onApplicationQuit != null){
                onApplicationQuit();
            }
        }

        void OnApplicationPause(bool isPause){
            if (onApplicationPause != null){
                onApplicationPause(isPause);
            }
        }

#if !ABSTRACT_UNITY
        void Awake() {
            if ( _current != null && _current != this ) {
                DestroyImmediate(this.gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            _current = this;
        }

#endif

#if ABSTRACT_UNITY
        public override void Update()
        {
#else
        public void Update()
        {
#endif

            if (onUpdate != null){ onUpdate(); }
        }

#if ABSTRACT_UNITY
        public override void LateUpdate()
        {
#else
            public void LateUpdate(){
#endif
            if (onLateUpdate != null){ onLateUpdate(); }
        }

#if ABSTRACT_UNITY
        public override void FixedUpdate()
        {
#else
             public void FixedUpdate(){
#endif
            if (onFixedUpdate != null){ onFixedUpdate(); }
        }

        public void OnGUI(){
            if (onGUI != null){ onGUI(); }
        }
    }
}