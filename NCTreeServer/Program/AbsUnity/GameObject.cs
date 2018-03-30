using System;
using System.Collections.Generic;

namespace AbsUnity
{
    public class GameObject : Object
    {
        public GameObject(string pName = "GameObject")
        {
            this.name = pName;
        }
        
        public GameObject gameObject
        {
            get  { return this; }
        }
        public Transform transform
        {
            set { _transform = value; }
            get
            {
                if (_transform == null)
                {
                    _transform = new Transform();
                    _transform.gameObject = gameObject;
                    GameObject.ComponentList.Add(_transform);
                }
                return _transform;
            }
        }

        public T AddComponent<T>() where T : Component
        {
            return this.AddComponent(typeof(T)) as T;
        }

        public Component AddComponent(Type componentType)
        {
            return this.Internal_AddComponentWithType(componentType);
        }

        public T GetComponent<T>() where T : Component
        {
            return GetComponent(typeof(T)) as T;
        }

        public Component GetComponent(Type type)
        {
            return this.Internal_GetComponentWithType(type);
        }

        public void SendMessage(string methodName)
        {
            
        }

        public void SendMessage(string methodName,  object arguments)
        {

        }

        #region Static
        public static void Update()
        {
            int len = GameObject.ComponentList.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.ComponentList[i].Update();
            }
        }

        public static void FixedUpdate()
        {
            int len = GameObject.ComponentList.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.ComponentList[i].FixedUpdate();
            }
        }
        #endregion


        #region Private
        Component Internal_AddComponentWithType(Type componentType)
        {
            object obj = Activator.CreateInstance(componentType, true);
            Component componet = (Component)obj;
            componet.gameObject = this.gameObject;
            componet.transform = this.transform;
            GameObject.ComponentList.Add(componet);
            return componet;
        }

        Component Internal_GetComponentWithType(Type type)
        {
            Component pComponent = GameObject.ComponentList.Find(x => x.GetType() == type);
            return pComponent;
        }
        #endregion

        #region MyRegion
        Transform _transform;
        public static List<Component> ComponentList = new List<Component>();
        #endregion
    }
}
