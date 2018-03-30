using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !ABSTRACT_UNITY

namespace NodeCanvas.Tasks.Conditions{

	[Category("GameObject")]
	public class IsActive : ConditionTask<Transform> {

		protected override bool OnCheck(){
			return agent.gameObject.activeInHierarchy;
		}
	}
}
#endif