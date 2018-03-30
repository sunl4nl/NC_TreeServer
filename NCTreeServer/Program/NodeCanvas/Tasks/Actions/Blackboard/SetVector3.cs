﻿using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Blackboard")]
	[Description("Set a blackboard Vector3 variable")]
	public class SetVector3 : ActionTask {

		[BlackboardOnly]
		public BBParameter<Vector3> valueA;
		public OperationMethod operation;
		public BBParameter<Vector3> valueB;

		protected override string info{
			get {return valueA + OperationTools.GetOperationString(operation) + valueB;}
		}

		protected override void OnExecute(){
			valueA.value = OperationTools.Operate(valueA.value, valueB.value, operation);
			EndAction();
		}
	}
}