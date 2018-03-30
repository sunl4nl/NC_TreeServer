using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class DestroyGameObject : ActionTask<Transform> {

		protected override string info{
			get {return string.Format("Destroy {0}", agentInfo);}
		}

		//in case it destroys self
		protected override void OnUpdate(){
#if ABSTRACT_UNITY
#else
            Object.Destroy(agent.gameObject);
#endif

            EndAction();
		}
	}
}