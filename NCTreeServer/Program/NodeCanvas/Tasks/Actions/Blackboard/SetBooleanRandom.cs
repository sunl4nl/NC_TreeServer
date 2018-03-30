using NodeCanvas.Framework;
using ParadoxNotion.Design;

#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Blackboard")]
	[Description("Set a blackboard boolean variable at random between min and max value")]
	public class SetBooleanRandom : ActionTask {

		[BlackboardOnly]
		public BBParameter<bool> boolVariable;

		protected override string info{
			get {return "Set " + boolVariable + " Random";}
		}

		protected override void OnExecute(){
#if ABSTRACT_UNITY
            System.Random r = new System.Random();
            boolVariable.value = r.Next(0, 2) == 0 ? false : true;
#else
            boolVariable.value = Random.Range(0, 2) == 0? false : true;
#endif

            EndAction();
		}
	}
}