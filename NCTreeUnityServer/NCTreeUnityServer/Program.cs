using System;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework.Internal;
using System.Threading;
using System.Text;
using Model;

namespace UnityEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Internal_Loop);
            Thread thread = new Thread(threadStart);
            thread.Start();

            //GameObject go = new GameObject("Unit");
            //MoveComponent move = go.AddComponent<MoveComponent>();
            //move.MoveTo(new Vector3(100, 0, 0));

            TestBTree();

            //Student s = new Student();
            //s.Age = 20;
            //StudentSecond ss = CloneExpV2<Student, StudentSecond>.Trans(s);
            //Loger.Log(ss);


        }

        static void Internal_Loop()
        {
            MainThreadRunner.Install();
            while (true)
            {
                try
                {
                    MainThreadRunner.Update();
                    //Game.EventSystem.Update();
                    DateTime beforDT = System.DateTime.Now;
                    SceneManager.Update();
                    DateTime afterDT = System.DateTime.Now;
                    TimeSpan ts = afterDT.Subtract(beforDT);
                    //Loger.Log("Update Use Milliseconds :" + ts.Milliseconds);
                    Thread.Sleep(20);

                    Time.deltaTime = (20 + ts.Milliseconds) / 1000.0f;
                    Time.time += Time.deltaTime;

                }
                catch (Exception e)
                {
                    Loger.LogError(e);
                }
            }
        }
        

        static void TestBTree()
        {
            GameObject rootObj = new GameObject("Unit");
            BehaviourTreeOwner owner = rootObj.AddComponent<BehaviourTreeOwner>();
            BehaviourTree jsonTree = new BehaviourTree();
            string path = "./../../Resources/LLogTree.BT";
            //string path = "./../../Resources/LLogTree.BT";
            string jsonGraph = System.IO.File.ReadAllText(path);
            Console.WriteLine(jsonGraph);

            GraphSerializationData graphData = jsonTree.Deserialize(jsonGraph, true, null);
            owner.StartBehaviour(jsonTree, (bool val) =>
            {
                Loger.Log("StartBehaviour Callback : " + val);
            });
        }
    }
}
