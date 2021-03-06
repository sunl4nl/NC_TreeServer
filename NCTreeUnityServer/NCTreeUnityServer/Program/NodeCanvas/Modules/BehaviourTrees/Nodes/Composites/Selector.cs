using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

	[Category("Composites")]
	[Description("Execute the child nodes in order or randonly until the first that returns Success and return Success as well. If none returns Success, then returns Failure.\nIf is Dynamic, then higher priority children Status are revaluated and if one returns Success the Selector will select that one and bail out immediately in Success too")]
	[Icon("Selector")]
	[Color("b3ff7f")]
	public class Selector : BTComposite{

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

                    case Status.Success:

				        if (dynamic && i < lastRunningNodeIndex)
				            outConnections[lastRunningNodeIndex].Reset();

				        return Status.Success;
				}
			}

			return Status.Failure;
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
#if SERVER_UNITY
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