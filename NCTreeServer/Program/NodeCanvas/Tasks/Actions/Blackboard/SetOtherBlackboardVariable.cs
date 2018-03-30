﻿using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{
 
    [Category("✫ Blackboard")]
    [Description("Use this to set a variable on any blackboard by overriding the agent")]
    public class SetOtherBlackboardVariable : ActionTask<Blackboard> {

        [RequiredField]
        public BBParameter<string> targetVariableName;
        public BBObjectParameter newValue;
       
        protected override string info{
            get {return string.Format("<b>{0}</b> = {1}", targetVariableName.ToString(), newValue != null? newValue.ToString() : ""); }
        }

        protected override void OnExecute(){
            agent.SetValue(targetVariableName.value, newValue.value);
            EndAction();
        }

        ////////////////////////////////////////
        ///////////GUI AND EDITOR STUFF/////////
        ////////////////////////////////////////
        #if UNITY_EDITOR
        
        protected override void OnTaskInspectorGUI(){
            DrawDefaultInspector();
            if (GUILayout.Button("Select Type")){
                EditorUtils.ShowPreferedTypesSelectionMenu(typeof(object), (t)=> {newValue.SetType(t);} );
            }
        }
        
        #endif
    }
}
 