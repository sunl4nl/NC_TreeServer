using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class CreateGameObject : ActionTask {

		public BBParameter<string> objectName;
		public BBParameter<Vector3> position;
		public BBParameter<Vector3> rotation;
		
		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override void OnExecute(){
			var newGO = new GameObject(objectName.value);
			newGO.transform.position = position.value;
			newGO.transform.eulerAngles = rotation.value;
			saveAs.value = newGO;
			EndAction();
		}
	}
}