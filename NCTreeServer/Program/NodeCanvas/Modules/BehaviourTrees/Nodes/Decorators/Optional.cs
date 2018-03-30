using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

	[Name("Optional")]
	[Category("Decorators")]
	[Description("Executes the decorated node without taking into account it's return status, thus making it optional to the parent node for whether it returns Success or Failure.\nThis has the same effect as disabling the node, but instead it executes normaly")]
	public class Optional : BTDecorator{

		protected override Status OnExecute(Component agent, IBlackboard blackboard){

			if (decoratedConnection == null)
				return Status.Resting;

		    if (status == Status.Resting)
		    	decoratedConnection.Reset();

			status = decoratedConnection.Execute(agent, blackboard);
			return status == Status.Running? Status.Running : Status.Resting;
		}
	}
}