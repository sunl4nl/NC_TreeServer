using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if !SERVER_UNITY
using UnityEngine;
 
namespace NodeCanvas.Tasks.Actions
{
    [Category("GameObject")]
    public class InstantiateGameObject : ActionTask<Transform> {
        public BBParameter<Transform> parent;
        public BBParameter<Vector3> clonePosition;
        public BBParameter<Vector3> cloneRotation;
        [BlackboardOnly]
        public BBParameter<GameObject> saveCloneAs;
 
        protected override string info{
            get { return "Instantiate " + agentInfo + " under " + (parent.value ? parent.ToString() : "World") + " at " + clonePosition + " as " + saveCloneAs; }
        }
 
        protected override void OnExecute(){
            var clone = (GameObject)Object.Instantiate(agent.gameObject);
            clone.transform.SetParent(parent.value);
            clone.transform.position = clonePosition.value;
            clone.transform.eulerAngles = cloneRotation.value;
            saveCloneAs.value = clone;
            EndAction();
        }
    }
}
#endif