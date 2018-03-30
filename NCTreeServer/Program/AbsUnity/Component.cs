using System;
using System.Collections.Generic;

namespace AbsUnity
{
    public class Component : Object
    {   
        public GameObject gameObject
        {
            get { return _gameobject; }
            set { _gameobject = value; }
        }
        public Transform transform
        {
            get { return _transform; }
            set { _transform = value; }
        }

        public Component GetComponent(Type type)
        {
            return this.gameObject.GetComponent(type);
        }

        public T GetComponent<T>() where T : Component
        {
            return this.gameObject.GetComponent<T>();
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void LateUpdate()
        {

        }

        #region MyRegion
        GameObject _gameobject;
        Transform _transform;
        #endregion
    }
}
