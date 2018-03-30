﻿using System.Collections.Generic;
using ParadoxNotion;

#if ABSTRACT_UNITY
using AbsUnity;
#else 
using UnityEngine;
#endif

namespace NodeCanvas.Framework{

	///An interface used to provide default agent and blackboard references to tasks and let tasks 'interface' with the root system
	public interface ITaskSystem{
		Component agent {get;}
		IBlackboard blackboard {get;}
		float elapsedTime {get;}
		Object contextObject{get;}
		void SendTaskOwnerDefaults();
		void SendEvent(EventData eventData);
	}
}