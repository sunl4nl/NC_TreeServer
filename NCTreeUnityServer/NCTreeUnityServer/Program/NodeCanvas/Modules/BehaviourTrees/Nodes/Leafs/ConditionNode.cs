using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

	[Name("Condition")]
	[Description("Check a condition and return Success or Failure")]
	[Icon("Condition")]
	public class ConditionNode : BTNode, ITaskAssignable<ConditionTask>{

		[SerializeField]
		private ConditionTask _condition;

		public Task task{
			get {return condition;}
			set {condition = (ConditionTask)value;}
		}

		public ConditionTask condition{
			get{return _condition;}
			set{_condition = value;}
		}

		public override string name{
			get{return base.name.ToUpper();}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard){
			if (condition != null)
				return condition.CheckCondition(agent, blackboard)? Status.Success: Status.Failure;
			return Status.Failure;
		}
	}
}