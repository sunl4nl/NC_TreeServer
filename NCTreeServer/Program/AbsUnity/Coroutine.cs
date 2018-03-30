using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AbsUnity
{
    public class YieldInstruction
    {
    }

    public sealed class Coroutine : YieldInstruction
    {
        internal IntPtr m_Ptr;

        private Coroutine()
        {
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void ReleaseCoroutine();

        ~Coroutine()
        {
            this.ReleaseCoroutine();
        }
    }
}
