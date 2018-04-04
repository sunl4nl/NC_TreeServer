using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public struct AnimatorClipInfo
    {
        private int m_ClipInstanceID;

        private float m_Weight;

        public float weight
        {
            get
            {
                return this.m_Weight;
            }
        }
    }
}
