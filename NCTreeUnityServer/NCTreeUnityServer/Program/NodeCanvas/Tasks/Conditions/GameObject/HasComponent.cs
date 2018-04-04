using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Conditions{

	[Category("GameObject")]
	public class HasComponent<T> : ConditionTask<Transform> where T:Component{

		protected override bool OnCheck(){
			return agent.GetComponent<T>() != null;
		}
	}
}