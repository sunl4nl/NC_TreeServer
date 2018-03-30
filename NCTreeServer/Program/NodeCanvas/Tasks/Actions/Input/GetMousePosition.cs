using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !ABSTRACT_UNITY
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class GetMousePosition : ActionTask {

		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;
		public bool repeat;


		protected override void OnExecute(){ Do(); }
		protected override void OnUpdate(){ Do(); }

		void Do(){
			saveAs.value = Input.mousePosition;
			if (!repeat)
				EndAction();
		}
	}
}
#endif