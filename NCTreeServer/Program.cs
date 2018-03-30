using System;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework.Internal;
using AbsUnity;
using System.Threading;
using System.Text;

namespace AbsUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Internal_Loop);
            Thread thread = new Thread(threadStart);
            thread.Start();

            //TestCase
            TestBTree();
        }

        static void Internal_Loop()
        {
            while (true)
            {
                DateTime beforDT = System.DateTime.Now;

                //Update
                Update();
                FixedUpdate();
                //End Update

                DateTime afterDT = System.DateTime.Now;
                TimeSpan ts = afterDT.Subtract(beforDT);
                System.Threading.Thread.Sleep(20 + ts.Milliseconds);

                Time.deltaTime = (20 + ts.Milliseconds) / 1000.0f;
                Time.time += Time.deltaTime;
            }
        }

        static void Update()
        {
            GameObject.Update();
        }

        static void FixedUpdate()
        {
            GameObject.FixedUpdate();
        }

        static void TestBTree()
        {
            GameObject rootObj = new GameObject();
            BehaviourTreeOwner owner = rootObj.AddComponent<BehaviourTreeOwner>();
            BehaviourTree jsonTree = new BehaviourTree();
            string path = "./../../Resources/LLogTree.BT";
            string jsonGraph = System.IO.File.ReadAllText(path);
            Console.WriteLine("jsonGraph {0} ", jsonGraph);

            GraphSerializationData graphData =  jsonTree.Deserialize(jsonGraph, true, null);
            owner.StartBehaviour(jsonTree, (bool val) =>
            {
                Console.WriteLine(val);
            });
        }
    }
}
