using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UnityEngine
{
    public sealed class AudioClip : Object
    {
        public delegate void PCMReaderCallback(float[] data);

        public delegate void PCMSetPositionCallback(int position);

        private event AudioClip.PCMReaderCallback m_PCMReaderCallback;

        private event AudioClip.PCMSetPositionCallback m_PCMSetPositionCallback;

        public float length
        {
            get;
        }

        public int samples
        {
            get;
        }

        public int channels
        {
            get;
        }

        public int frequency
        {
            get;
        }
        

        public bool preloadAudioData
        {
            get;
        }

        public bool ambisonic
        {
            get;
        }

        public bool loadInBackground
        {
            get;
        }

        public AudioClip()
        {
            this.m_PCMReaderCallback = null;
            this.m_PCMSetPositionCallback = null;
        }


        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream)
        {
            return AudioClip.Create(name, lengthSamples, channels, frequency, stream, null, null);
        }

        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, AudioClip.PCMReaderCallback pcmreadercallback)
        {
            return AudioClip.Create(name, lengthSamples, channels, frequency, stream, pcmreadercallback, null);
        }

        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, AudioClip.PCMReaderCallback pcmreadercallback, AudioClip.PCMSetPositionCallback pcmsetpositioncallback)
        {
            if (name == null)
            {
                throw new NullReferenceException();
            }
            if (lengthSamples <= 0)
            {
                throw new ArgumentException("Length of created clip must be larger than 0");
            }
            if (channels <= 0)
            {
                throw new ArgumentException("Number of channels in created clip must be greater than 0");
            }
            if (frequency <= 0)
            {
                throw new ArgumentException("Frequency in created clip must be greater than 0");
            }
            AudioClip audioClip = AudioClip.Construct_Internal();
            if (pcmreadercallback != null)
            {
                audioClip.m_PCMReaderCallback += pcmreadercallback;
            }
            if (pcmsetpositioncallback != null)
            {
                audioClip.m_PCMSetPositionCallback += pcmsetpositioncallback;
            }
            audioClip.Init_Internal(name, lengthSamples, channels, frequency, stream);
            return audioClip;
        }

        private void InvokePCMReaderCallback_Internal(float[] data)
        {
            if (this.m_PCMReaderCallback != null)
            {
                this.m_PCMReaderCallback(data);
            }
        }

        private void InvokePCMSetPositionCallback_Internal(int position)
        {
            if (this.m_PCMSetPositionCallback != null)
            {
                this.m_PCMSetPositionCallback(position);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern AudioClip Construct_Internal();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void Init_Internal(string name, int lengthSamples, int channels, int frequency, bool stream);
    }
}
