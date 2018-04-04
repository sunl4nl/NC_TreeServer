using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !SERVER_UNITY
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class FindWithTag : ActionTask{

		[RequiredField] [TagField]
		public string searchTag = "Untagged";
		
		[BlackboardOnly]
		public BBParameter<GameObject> saveAs;

		protected override string info{
			get{return "GetObject '" + searchTag + "' as " + saveAs;}
		}

		protected override void OnExecute(){

			saveAs.value = GameObject.FindWithTag(searchTag);
			EndAction(true);
		}
	}
}
#endif