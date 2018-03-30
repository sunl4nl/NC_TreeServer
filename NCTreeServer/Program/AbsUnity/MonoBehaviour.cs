using System;
using System.Collections;
using System.Collections.Generic;

namespace AbsUnity
{
    public class MonoBehaviour : Component
    {
        public MonoBehaviour()
        {
            Awake();
            Start();
        }
    
        public virtual void Awake()
        {
        }

        public virtual void Start()
        {
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return null;
        }

        public void StopCoroutine(Coroutine routine)
        {

        }

        public bool enabled
        {
            set; get;
        }

        #region MyRegion
        //float timeElapsedInMS;
        #endregion
    }
}
