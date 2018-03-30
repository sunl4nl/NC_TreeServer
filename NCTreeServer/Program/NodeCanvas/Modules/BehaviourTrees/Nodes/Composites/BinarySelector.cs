using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

	[Category("Composites")]
	[Description("Quick way to execute the left, or the right child node based on a Condition Task evaluation.")]
	[Icon("Condition")]
	[Color("b3ff7f")]
	public class BinarySelector : BTNode, ITaskAssignable<ConditionTask> {

		public bool dynamic;

		[SerializeField]
		private ConditionTask _condition;

		private int succeedIndex;

		public override int maxOutConnections{ get {return 2;}}
		public override bool showCommentsBottom{ get{return false;}}

		public override string name{
			get {return base.name.ToUpper();}
		}

		public Task task{
			get {return condition;}
			set {condition = (ConditionTask)value;}
		}

		private ConditionTask condition{
			get {return _condition;}
			set {_condition = value;}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard){

			if (condition == null || outConnections.Count < 2){
				return Status.Failure;
			}

			if (dynamic || status == Status.Resting){
				var lastIndex = succeedIndex;
				succeedIndex = condition.CheckCondition(agent, blackboard)? 0 : 1;
				if (succeedIndex != lastIndex){
					outConnections[lastIndex].Reset();
				}
			}

			return outConnections[succeedIndex].Execute(agent, blackboard);
		}


		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

		public override string GetConnectionInfo(int i){
			return i == 0? "TRUE" : "FALSE";
		}

		protected override void OnNodeGUI(){
			if (dynamic){
				GUILayout.Label("<b>DYNAMIC</b>");			
			}
		}
		
		#endif
	}
}