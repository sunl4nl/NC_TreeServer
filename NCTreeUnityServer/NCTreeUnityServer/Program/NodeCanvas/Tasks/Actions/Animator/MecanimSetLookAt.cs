using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !SERVER_UNITY
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Name("Set Look At")]
	[Category("Animator")]
	[EventReceiver("OnAnimatorIK")]
	public class MecanimSetLookAt : ActionTask<Animator> {

		public BBParameter<GameObject> targetPosition;
		public BBParameter<float> targetWeight;

		protected override string info{
			get{return "Mec.SetLookAt " + targetPosition;}
		}

		public void OnAnimatorIK(){

			agent.SetLookAtPosition(targetPosition.value.transform.position);
			agent.SetLookAtWeight(targetWeight.value);
			EndAction();
		}
	}
}
#endif