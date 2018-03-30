using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AbsUnity
{
    public sealed class RectOffset
    {
        [NonSerialized]
        internal IntPtr m_Ptr;

        private readonly object m_SourceStyle;

        public int left
        {
            get;
            set;
        }

        public int right
        {
            get;
            set;
        }

        public int top
        {
            get;
            set;
        }

        public int bottom
        {
            get;
            set;
        }

        public int horizontal
        {
            get;
        }

        public int vertical
        {
            get;
        }

        public RectOffset()
        {
            this.Init();
        }

        internal RectOffset(object sourceStyle, IntPtr source)
        {
            this.m_SourceStyle = sourceStyle;
            this.m_Ptr = source;
        }

        public RectOffset(int left, int right, int top, int bottom)
        {
            this.Init();
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
        }
        private void Init()
        {
        }

        private void Cleanup()
        {
        }

        public Rect Add(Rect rect)
        {
            Rect result;
            RectOffset.INTERNAL_CALL_Add(this, ref rect, out result);
            return result;
        }

        private static void INTERNAL_CALL_Add(RectOffset self, ref Rect rect, out Rect value)
        {
            value = new Rect();
        }

        public Rect Remove(Rect rect)
        {
            Rect result;
            RectOffset.INTERNAL_CALL_Remove(this, ref rect, out result);
            return result;
        }

        private static void INTERNAL_CALL_Remove(RectOffset self, ref Rect rect, out Rect value)
        {
            value = new Rect();
        }

        ~RectOffset()
        {
            if (this.m_SourceStyle == null)
            {
                this.Cleanup();
            }
        }

        public override string ToString()
        {
            return string.Format("RectOffset (l:{0} r:{1} t:{2} b:{3})", new object[]
            {
                this.left,
                this.right,
                this.top,
                this.bottom
            });
        }
    }
}
