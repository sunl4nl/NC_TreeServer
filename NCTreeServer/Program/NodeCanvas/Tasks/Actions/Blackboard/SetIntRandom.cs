using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Name("Set Integer Random")]
	[Category("✫ Blackboard")]
	[Description("Set a blackboard integer variable at random between min and max value")]
	public class SetIntRandom : ActionTask {

		public BBParameter<int> minValue;
		public BBParameter<int> maxValue;

		[BlackboardOnly]
		public BBParameter<int> intVariable;

		protected override string info{
			get {return "Set " + intVariable + " Random(" + minValue + ", " + maxValue + ")";}
		}

		protected override void OnExecute(){
#if ABSTRACT_UNITY  
            System.Random r = new System.Random();
            intVariable.value = r.Next(minValue.value, maxValue.value + 1);
#else
            intVariable.value = Random.Range(minValue.value, maxValue.value + 1);
#endif

            EndAction();
		}
	}
}