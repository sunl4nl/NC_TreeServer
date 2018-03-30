﻿using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !ABSTRACT_UNITY


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Utility")]
	public class DebugDrawLine : ActionTask {

		public BBParameter<Vector3> from;
		public BBParameter<Vector3> to;
		public Color color = Color.white;
		public float timeToShow = 0.1f;

		protected override void OnExecute(){
			Debug.DrawLine(from.value, to.value, color, timeToShow);
			EndAction(true);
		}
	}
}
#endif