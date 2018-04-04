﻿using NodeCanvas.Framework;
#if SERVER_UNITY
using UnityEngine;
#else 
using UnityEngine;
#endif


namespace NodeCanvas.BehaviourTrees{

    /// <summary>
    /// Use this component on a game object to behave based on a BehaviourTree.
    /// </summary>
#if !SERVER_UNITY
    [AddComponentMenu("NodeCanvas/Behaviour Tree Owner")]
#endif
	public class BehaviourTreeOwner : GraphOwner<BehaviourTree> {

		///Should the assigned BT reset and re-execute after a cycle? Sets the BehaviourTree's repeat
		public bool repeat{
			get {return behaviour != null? behaviour.repeat : true;}
			set {if (behaviour != null) behaviour.repeat = value;}
		}

		///The interval in seconds to update the BT. 0 for every frame. Sets the BehaviourTree's updateInterval
		public float updateInterval{
			get {return behaviour != null? behaviour.updateInterval : 0;}
			set {if (behaviour != null) behaviour.updateInterval = value;}
		}

		///The last status of the assigned Behaviour Tree's root node (aka Start Node)
		public Status rootStatus{
			get {return behaviour != null? behaviour.rootStatus : Status.Resting;}
		}

		///Ticks the assigned Behaviour Tree for this owner agent and returns it's root status
		public Status Tick(){
			
			if (behaviour == null){
#if !SERVER_UNITY
                Debug.LogWarning("There is no Behaviour Tree assigned", gameObject);
#endif
                return Status.Resting;
			}

#if !SERVER_UNITY
			return behaviour.Tick(this, blackboard);
#else
            return new Status();
#endif
        }
	}
}