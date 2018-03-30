using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbsUnity
{
    public class TestMono : MonoBehaviour
    {
        public override void Update()
        {
            Console.WriteLine(Time.time);
        }
    }
}
