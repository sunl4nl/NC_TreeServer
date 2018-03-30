using System;

namespace AbsUnity
{
    public sealed class Time
    {
        public static float time
        {
            get;
            set;
        }

        public static float timeSinceLevelLoad
        {
            get;
        }

        public static float deltaTime
        {
            get;
            set;
        }

        public static float fixedTime
        {   
            get;
            set;
        }

        public static float unscaledTime
        {
            get;
        }

        public static float fixedUnscaledTime
        {
            get;
        }

        public static float unscaledDeltaTime
        {
            get;
        }

        public static float fixedUnscaledDeltaTime
        {
            get;
        }

        public static float fixedDeltaTime
        {
            get;
            set;
        }
        
        public static float timeScale
        {
            get;
            set;
        }

        public static int frameCount
        {
            get;
        }

        public static float realtimeSinceStartup
        {
            get;
        }
    }
}
