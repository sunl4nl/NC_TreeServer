using System;
using System.Collections;
using System.Collections.Generic;

namespace AbsUnity
{
    public class Transform : Component, IEnumerable
    {
        private sealed class Enumerator : IEnumerator
        {
            private Transform outer;

            private int currentIndex = -1;

            public object Current
            {
                get
                {
                    return this.outer.GetChild(this.currentIndex);
                }
            }

            internal Enumerator(Transform outer)
            {
                this.outer = outer;
            }

            public bool MoveNext()
            {
                int childCount = this.outer.childCount;
                return ++this.currentIndex < childCount;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }

        public void SetParent(Transform parent)
        {
            parent.AddChild(this);
        }

        public void AddChild(Transform pChild)
        {
            _childList.Add(pChild);
        }

        public int childCount
        {
            get { return _childList.Count;  }
        }

        public Transform GetChild(int index)
        {
            if (index < _childList.Count)
            {
                return _childList[index];
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return new Transform.Enumerator(this);
        }

        public Vector3 position
        {
            get; set;
        }

        public Vector3 eulerAngles
        {
            get; set;
        }

        public Quaternion rotation
        {
            get; set;
        }
        public Vector3 forward
        {
            get
            {
                return this.rotation * Vector3.forward;
            }
            set
            {
                this.rotation = Quaternion.LookRotation(value);
            }
        }
        public void SendMessage(string methodName)
        {

        }

        public void SendMessage(string methodName, object value)
        {

        }
        #region MyRegion
        List<Transform> _childList = new List<Transform>();
        #endregion
    }
}
