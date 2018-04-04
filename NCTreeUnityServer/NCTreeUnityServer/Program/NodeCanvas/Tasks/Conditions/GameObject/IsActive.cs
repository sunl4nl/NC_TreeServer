using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !SERVER_UNITY
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{

	[Category("GameObject")]
	public class IsActive : ConditionTask<Transform> {

		protected override bool OnCheck(){
			return agent.gameObject.activeInHierarchy;
		}
	}
}
#endif