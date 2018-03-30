#define ABSTRACT_UNITY
#if ABSTRACT_UNITY
using AbsUnity;
#else
using UnityEngine;
#endif
using System.Collections.Generic;

namespace ParadoxNotion{

	///An interface used for ScriptableObjects attached to gameObjects
	public interface IScriptableComponent{}
}