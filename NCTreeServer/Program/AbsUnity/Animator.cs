using System;

namespace AbsUnity
{ 
    public class Animator : Component
    {
        public Animator()
        {
            Console.WriteLine("Animator");
        }

        public void LogMsg(string p)
        {
            Console.WriteLine(p);
        }
    }
}
