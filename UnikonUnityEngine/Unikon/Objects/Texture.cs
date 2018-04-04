using System;

namespace UnityEngine
{
    public class Texture : Object
    {

        public virtual int width
        {
            get
            {
                return 0;
            }
            set
            {
                throw new Exception("not implemented");
            }
        }

        public virtual int height
        {
            get
            {
                return 0;
            }
            set
            {
                throw new Exception("not implemented");
            }
        }
    }
}
