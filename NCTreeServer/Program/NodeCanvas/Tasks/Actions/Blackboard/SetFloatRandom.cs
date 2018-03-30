using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Blackboard")]
	[Description("Set a blackboard float variable at random between min and max value")]
	public class SetFloatRandom : ActionTask {

		public BBParameter<float> minValue;
		public BBParameter<float> maxValue;

		[BlackboardOnly]
		public BBParameter<float> floatVariable;

		protected override string info{
			get {return "Set " + floatVariable + " Random(" + minValue + ", " + maxValue + ")";}
		}

		protected override void OnExecute(){

#if ABSTRACT_UNITY
            System.Random r = new System.Random();
            floatVariable.value = r.Next((int)minValue.value, (int)maxValue.value);
#else
            floatVariable.value = Random.Range(minValue.value, maxValue.value);
#endif

            EndAction();
		}
	}
}