using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
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
#if SERVER_UNITY
#else
            Object.Destroy(agent.gameObject);
#endif

            EndAction();
		}
	}
}