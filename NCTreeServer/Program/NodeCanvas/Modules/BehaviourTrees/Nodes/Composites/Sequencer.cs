using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

	[Category("Composites")]
	[Description("Execute the child nodes in order or randonly and return Success if all children return Success, else return Failure\nIf is Dynamic, higher priority child status is revaluated. If a child returns Failure the Sequencer will bail out immediately in Failure too.")]
	[Icon("Sequencer")]
	[Color("bf7fff")]
	public class Sequencer : BTComposite {

		public bool dynamic;
		public bool random;

		private int lastRunningNodeIndex= 0;

		public override string name{
			get {return base.name.ToUpper();}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard){

			for ( var i= dynamic? 0 : lastRunningNodeIndex; i < outConnections.Count; i++){

				status = outConnections[i].Execute(agent, blackboard);

				switch(status)
                {
                    case Status.Running:

				        if (dynamic && i < lastRunningNodeIndex)
				            outConnections[lastRunningNodeIndex].Reset();
						
				        lastRunningNodeIndex = i;
				        return Status.Running;

                    case Status.Failure:

				        if (dynamic && i < lastRunningNodeIndex)
				            outConnections[lastRunningNodeIndex].Reset();

				        return Status.Failure;
				}
			}

			return Status.Success;
		}

		protected override void OnReset(){
			lastRunningNodeIndex = 0;
			if (random)
				outConnections = Shuffle(outConnections);
		}

		public override void OnChildDisconnected(int index){
			if (index != 0 && index == lastRunningNodeIndex)
				lastRunningNodeIndex--;
		}

		public override void OnGraphStarted(){
			OnReset();
		}

		//Fisher-Yates shuffle algorithm
		private List<Connection> Shuffle(List<Connection> list){
			for ( var i= list.Count -1; i > 0; i--){
#if ABSTRACT_UNITY
                System.Random r = new System.Random();
                var j = r.Next(0, (i + 1));
#else
                var j = (int)Mathf.Floor(Random.value * (i + 1));
#endif
				var temp = list[i];
				list[i] = list[j];
				list[j] = temp;
			}

			return list;
		}

		/////////////////////////////////////////
		/////////GUI AND EDITOR STUFF////////////
		/////////////////////////////////////////
#if UNITY_EDITOR

		protected override void OnNodeGUI(){
			if (dynamic)
				GUILayout.Label("<b>DYNAMIC</b>");
			if (random)
				GUILayout.Label("<b>RANDOM</b>");
		}

#endif
	}
}