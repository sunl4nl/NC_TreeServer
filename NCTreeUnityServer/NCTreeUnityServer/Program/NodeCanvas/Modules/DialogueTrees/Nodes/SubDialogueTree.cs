using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.DialogueTrees{

	[Name("Sub Dialogue Tree")]
	[Category("Nested")]
	[Description("Execute a Sub Dialogue Tree. When that Dialogue Tree is finished, this node will continue instead if it has a connection.\nUseful for making reusable and self-contained Dialogue Trees.")]
	[Icon("Dialogue")]
	public class SubDialogueTree : DTNode, IGraphAssignable, ISubParametersContainer{

		BBParameter[] ISubParametersContainer.GetIncludeParseParameters(){
			return variablesMap.Values.ToArray();
		}

		[SerializeField]
		private BBParameter<DialogueTree> _subTree = null;
		[SerializeField]
		private Dictionary<string, string> actorParametersMap = new Dictionary<string, string>();
		[SerializeField]
		private Dictionary<string, BBObjectParameter> variablesMap = new Dictionary<string, BBObjectParameter>();

		private Dictionary<DialogueTree, DialogueTree> instances = new Dictionary<DialogueTree, DialogueTree>();

		public override string name{
			get {return "#" + ID + " SUB DIALOGUE";}
		}

		public DialogueTree subTree{
			get {return _subTree.value;}
			set {_subTree.value = value;}
		}

		Graph IGraphAssignable.nestedGraph{
			get {return subTree;}
			set {subTree = (DialogueTree)value;}
		}

		Graph[] IGraphAssignable.GetInstances(){ return instances.Values.ToArray(); }

		////

		protected override Status OnExecute(Component agent, IBlackboard bb){

			if (subTree == null){
				return Error("No Sub Dialogue Tree assigned!");
			}

			CheckInstance();
			SetActorParametersMapping();
			SetVariablesMapping();
			subTree.StartGraph(finalActor is Component? (Component)finalActor : finalActor.transform, bb, true, OnSubDialogueFinish );
			return Status.Running;
		}

		void SetActorParametersMapping(){
			foreach(var pair in actorParametersMap){
				var targetParam = subTree.GetParameterByID(pair.Key);
				var sourceParam = this.DLGTree.GetParameterByID(pair.Value);
				if (targetParam != null && sourceParam != null){
					subTree.SetActorReference(targetParam.name, sourceParam.actor);
				}
			}
		}

		void SetVariablesMapping(){
			foreach(var pair in variablesMap){
				if (!pair.Value.isNone){
					var targetVariable = subTree.blackboard.GetVariableByID(pair.Key);
					if (targetVariable != null){
						targetVariable.value = pair.Value.value;
					}
				}
			}
		}

		void OnSubDialogueFinish(bool success){
			status = success? Status.Success : Status.Failure;
			DLGTree.Continue();
		}

		public override void OnGraphStoped(){
			if (IsInstance(subTree)){
				subTree.Stop();
			}
		}

		public override void OnGraphPaused(){
			if (IsInstance(subTree)){
				subTree.Pause();
			}
		}

		bool IsInstance(DialogueTree dt){
			return instances.Values.Contains(dt);
		}

		void CheckInstance(){

			if (IsInstance(subTree)){
				return;
			}

			DialogueTree instance = null;
			if (!instances.TryGetValue(subTree, out instance)){
				instance = Graph.Clone<DialogueTree>(subTree);
				instances[subTree] = instance;
			}

            instance.agent = graphAgent;
		    instance.blackboard = graphBlackboard;
			subTree = instance;
		}

		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

	
		protected override void OnNodeGUI(){

			if (subTree != null){
				GUILayout.Label(_subTree.ToString());
				return;
			}

			if (GUILayout.Button("CREATE NEW")){
				Node.CreateNested<DialogueTree>(this);
			}
		}

		protected override void OnNodeInspectorGUI(){
			base.OnNodeInspectorGUI();
			EditorUtils.BBParameterField("Sub Dialogue Tree", _subTree);
			if (subTree == this.DLGTree){
				Debug.LogWarning("Nested DialogueTree can't be itself! Please select another");
				subTree = null;
			}

			if (subTree != null){
				ShowActorParametersMapping();
				ShowVariablesMapping();
			}
		}

		//Shows actor parameters mapping
		void ShowActorParametersMapping(){
			EditorUtils.TitledSeparator("SubTree Actor Parameters Mapping");
			UnityEditor.EditorGUILayout.HelpBox("You can set the SubDialogueTree's actor parameter references if any, by mapping them to the actor parameter references of this Dialogue Tree.", UnityEditor.MessageType.Info);

			if (subTree.actorParameters.Count == 0){
				return;
			}
			
			foreach(var param in subTree.actorParameters){
				if (!actorParametersMap.ContainsKey(param.ID)){
					actorParametersMap[param.ID] = string.Empty;
				}
				var currentParam = this.DLGTree.GetParameterByID( this.actorParametersMap[param.ID] );
				var newParam = EditorUtils.Popup<DialogueTree.ActorParameter>(param.name, currentParam, this.DLGTree.actorParameters);
				if (newParam != currentParam){
					this.actorParametersMap[param.ID] = newParam != null? newParam.ID : string.Empty;
				}
			}

			foreach(var key in actorParametersMap.Keys.ToList()){
				if (!subTree.actorParameters.Select(p => p.ID).Contains(key) ){
					actorParametersMap.Remove(key);
				}
			}
		}


		//Shows blackboard variables mapping
		void ShowVariablesMapping(){
			EditorUtils.TitledSeparator("SubTree Local Variables Mapping");
			UnityEditor.EditorGUILayout.HelpBox("You can set the SubDialogueTree's variables if any, by mapping them to the variables of this Dialogue Tree.\nIf set to 'NONE', the variable will not be affected.", UnityEditor.MessageType.Info);

			var subTreeVariables = subTree.blackboard.variables.Values.ToList();
			if (subTreeVariables.Count == 0){
				return;
			}

			foreach(var variable in subTreeVariables){

				if (variable is Variable<VariableSeperator>){
					continue;
				}

				if (variable.isProtected){
					UnityEditor.EditorGUILayout.LabelField(variable.name, "(Variable is Protected)");
					continue;
				}

				BBObjectParameter bbParam = null;
				if (!variablesMap.TryGetValue(variable.ID, out bbParam)){
					bbParam = variablesMap[variable.ID] = new BBObjectParameter(variable.varType){ useBlackboard = true };
					bbParam.bb = DLGTree.blackboard;
				}
				EditorUtils.BBParameterField(variable.name, bbParam);
			}

			foreach(var key in variablesMap.Keys.ToList()){
				if (!subTreeVariables.Select(v => v.ID).Contains(key)){
					variablesMap.Remove(key);
				}
			}
		}


		#endif
	}
}