﻿using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif

namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Blackboard/Lists")]
	public class AddElementToList<T> : ActionTask{
		[RequiredField] [BlackboardOnly]
		public BBParameter<List<T>> targetList;
		public BBParameter<T> targetElement;

		protected override string info{
			get {return string.Format("Add {0} In {1}", targetElement, targetList);}
		}

		protected override void OnExecute(){
			targetList.value.Add(targetElement.value);
			EndAction();
		}
	}
}