using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if ABSTRACT_UNITY
using System;
using AbsUnity;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Blackboard/Lists")]
	public class ShuffleList : ActionTask {

		[RequiredField] [BlackboardOnly]
		public BBParameter<IList> targetList;

		protected override void OnExecute(){
			
			var list = targetList.value;

			for ( var i= list.Count -1; i > 0; i--){
#if ABSTRACT_UNITY
                Random r = new Random();
                var j = r.Next(list.Count);
#else
                var j = (int)Mathf.Floor(Random.value * (i + 1));
#endif

                var temp = list[i];
				list[i] = list[j];
				list[j] = temp;
			}

			EndAction();
		}
	}
}