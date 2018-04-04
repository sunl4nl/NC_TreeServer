using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnityEngine
{

    public class AnimatorControllerParameter
    {

    }


    public sealed class Animator : Behaviour
    {
        public extern bool isOptimizable
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern bool isHuman
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern bool hasRootMotion
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        internal extern bool isRootPositionOrRotationControlledByCurves
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern float humanScale
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern bool isInitialized
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public Vector3 deltaPosition
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_deltaPosition(out result);
                return result;
            }
        }

        public Quaternion deltaRotation
        {
            get
            {
                Quaternion result;
                this.INTERNAL_get_deltaRotation(out result);
                return result;
            }
        }

        public Vector3 velocity
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_velocity(out result);
                return result;
            }
        }

        public Vector3 angularVelocity
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_angularVelocity(out result);
                return result;
            }
        }

        public Vector3 rootPosition
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_rootPosition(out result);
                return result;
            }
            set
            {
                this.INTERNAL_set_rootPosition(ref value);
            }
        }

        public Quaternion rootRotation
        {
            get
            {
                Quaternion result;
                this.INTERNAL_get_rootRotation(out result);
                return result;
            }
            set
            {
                this.INTERNAL_set_rootRotation(ref value);
            }
        }

        public extern bool applyRootMotion
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern bool linearVelocityBlending
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }
       

        public extern bool hasTransformHierarchy
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        internal extern bool allowConstantClipSamplingOptimization
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern float gravityWeight
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public Vector3 bodyPosition
        {
            get
            {
                this.CheckIfInIKPass();
                return this.GetBodyPositionInternal();
            }
            set
            {
                this.CheckIfInIKPass();
                this.SetBodyPositionInternal(value);
            }
        }

        public Quaternion bodyRotation
        {
            get
            {
                this.CheckIfInIKPass();
                return this.GetBodyRotationInternal();
            }
            set
            {
                this.CheckIfInIKPass();
                this.SetBodyRotationInternal(value);
            }
        }

        public extern bool stabilizeFeet
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern int layerCount
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern AnimatorControllerParameter parameters
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern int parameterCount
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern float feetPivotActive
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern float pivotWeight
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public Vector3 pivotPosition
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_pivotPosition(out result);
                return result;
            }
        }

        public extern bool isMatchingTarget
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern float speed
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public Vector3 targetPosition
        {
            get
            {
                Vector3 result;
                this.INTERNAL_get_targetPosition(out result);
                return result;
            }
        }

        public Quaternion targetRotation
        {
            get
            {
                Quaternion result;
                this.INTERNAL_get_targetRotation(out result);
                return result;
            }
        }

        internal extern Transform avatarRoot
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }


        public extern float playbackTime
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern float recorderStartTime
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern float recorderStopTime
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }
        

        public extern RuntimeAnimatorController runtimeAnimatorController
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern bool hasBoundPlayables
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern bool layersAffectMassCenter
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern float leftFeetBottomHeight
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern float rightFeetBottomHeight
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        internal extern bool supportsOnAnimatorMove
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public extern bool logWarnings
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        public extern bool fireEvents
        {
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
            
            [MethodImpl(MethodImplOptions.InternalCall)]
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Stop is obsolete. Use Animator.enabled = false instead", true)]
        public void Stop()
        {
        }

        public float GetFloat(string name)
        {
            return this.GetFloatString(name);
        }

        public float GetFloat(int id)
        {
            return this.GetFloatID(id);
        }

        public void SetFloat(string name, float value)
        {
            this.SetFloatString(name, value);
        }

        public void SetFloat(string name, float value, float dampTime, float deltaTime)
        {
            this.SetFloatStringDamp(name, value, dampTime, deltaTime);
        }

        public void SetFloat(int id, float value)
        {
            this.SetFloatID(id, value);
        }

        public void SetFloat(int id, float value, float dampTime, float deltaTime)
        {
            this.SetFloatIDDamp(id, value, dampTime, deltaTime);
        }

        public bool GetBool(string name)
        {
            return this.GetBoolString(name);
        }

        public bool GetBool(int id)
        {
            return this.GetBoolID(id);
        }

        public void SetBool(string name, bool value)
        {
            this.SetBoolString(name, value);
        }

        public void SetBool(int id, bool value)
        {
            this.SetBoolID(id, value);
        }

        public int GetInteger(string name)
        {
            return this.GetIntegerString(name);
        }

        public int GetInteger(int id)
        {
            return this.GetIntegerID(id);
        }

        public void SetInteger(string name, int value)
        {
            this.SetIntegerString(name, value);
        }

        public void SetInteger(int id, int value)
        {
            this.SetIntegerID(id, value);
        }

        public void SetTrigger(string name)
        {
            this.SetTriggerString(name);
        }

        public void SetTrigger(int id)
        {
            this.SetTriggerID(id);
        }

        public void ResetTrigger(string name)
        {
            this.ResetTriggerString(name);
        }

        public void ResetTrigger(int id)
        {
            this.ResetTriggerID(id);
        }

        public bool IsParameterControlledByCurve(string name)
        {
            return this.IsParameterControlledByCurveString(name);
        }

        public bool IsParameterControlledByCurve(int id)
        {
            return this.IsParameterControlledByCurveID(id);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_deltaPosition(out Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_deltaRotation(out Quaternion value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_velocity(out Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_angularVelocity(out Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_rootPosition(out Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_set_rootPosition(ref Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_rootRotation(out Quaternion value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_set_rootRotation(ref Quaternion value);

        internal Vector3 GetBodyPositionInternal()
        {
            Vector3 result;
            Animator.INTERNAL_CALL_GetBodyPositionInternal(this, out result);
            return result;
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_GetBodyPositionInternal(Animator self, out Vector3 value);

        internal void SetBodyPositionInternal(Vector3 bodyPosition)
        {
            Animator.INTERNAL_CALL_SetBodyPositionInternal(this, ref bodyPosition);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_SetBodyPositionInternal(Animator self, ref Vector3 bodyPosition);

        internal Quaternion GetBodyRotationInternal()
        {
            Quaternion result;
            Animator.INTERNAL_CALL_GetBodyRotationInternal(this, out result);
            return result;
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_GetBodyRotationInternal(Animator self, out Quaternion value);

        internal void SetBodyRotationInternal(Quaternion bodyRotation)
        {
            Animator.INTERNAL_CALL_SetBodyRotationInternal(this, ref bodyRotation);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_SetBodyRotationInternal(Animator self, ref Quaternion bodyRotation);

       

        public void SetLookAtPosition(Vector3 lookAtPosition)
        {
            this.CheckIfInIKPass();
            this.SetLookAtPositionInternal(lookAtPosition);
        }

        internal void SetLookAtPositionInternal(Vector3 lookAtPosition)
        {
            Animator.INTERNAL_CALL_SetLookAtPositionInternal(this, ref lookAtPosition);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_SetLookAtPositionInternal(Animator self, ref Vector3 lookAtPosition);

        

        internal void SetBoneLocalRotationInternal(int humanBoneId, Quaternion rotation)
        {
            Animator.INTERNAL_CALL_SetBoneLocalRotationInternal(this, humanBoneId, ref rotation);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void INTERNAL_CALL_SetBoneLocalRotationInternal(Animator self, int humanBoneId, ref Quaternion rotation);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern ScriptableObject GetBehaviour(Type type);

        public T GetBehaviour<T>() where T : StateMachineBehaviour
        {
            return this.GetBehaviour(typeof(T)) as T;
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern ScriptableObject InternalGetBehaviours(Type type);

        internal static T ConvertStateMachineBehaviour<T>(ScriptableObject rawObjects) where T : StateMachineBehaviour
        {
            T result = default(T);
            if (rawObjects == null)
            {
                result = null;
            }
            return result;
        }

        public T GetBehaviours<T>() where T : StateMachineBehaviour
        {
            return Animator.ConvertStateMachineBehaviour<T>(this.InternalGetBehaviours(typeof(T)));
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern StateMachineBehaviour InternalGetBehavioursByKey(int fullPathHash, int layerIndex, Type type);

        public StateMachineBehaviour GetBehaviours(int fullPathHash, int layerIndex)
        {
            return this.InternalGetBehavioursByKey(fullPathHash, layerIndex, typeof(StateMachineBehaviour));
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string GetLayerName(int layerIndex);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int GetLayerIndex(string layerName);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern float GetLayerWeight(int layerIndex);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void SetLayerWeight(int layerIndex, float weight);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex);


        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int GetCurrentAnimatorClipInfoCount(int layerIndex);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern AnimatorClipInfo GetCurrentAnimatorClipInfo(int layerIndex);

        public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
        {
            if (clips == null)
            {
                throw new ArgumentNullException("clips");
            }
            this.GetAnimatorClipInfoInternal(layerIndex, true, clips);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void GetAnimatorClipInfoInternal(int layerIndex, bool isCurrent, object clips);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int GetNextAnimatorClipInfoCount(int layerIndex);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern AnimatorClipInfo GetNextAnimatorClipInfo(int layerIndex);

        public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
        {
            if (clips == null)
            {
                throw new ArgumentNullException("clips");
            }
            this.GetAnimatorClipInfoInternal(layerIndex, false, clips);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool IsInTransition(int layerIndex);

        public AnimatorControllerParameter GetParameter(int index)
        {
            AnimatorControllerParameter parameters = this.parameters;
            return parameters;
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_pivotPosition(out Vector3 value);

       
        [Obsolete("ForceStateNormalizedTime is deprecated. Please use Play or CrossFade instead.")]
        public void ForceStateNormalizedTime(float normalizedTime)
        {
            this.Play(0, 0, normalizedTime);
        }

        public void CrossFadeInFixedTime(string stateName, float transitionDuration, int layer)
        {
            float fixedTime = 0f;
            this.CrossFadeInFixedTime(stateName, transitionDuration, layer, fixedTime);
        }

        public void CrossFadeInFixedTime(string stateName, float transitionDuration)
        {
            float fixedTime = 0f;
            int layer = -1;
            this.CrossFadeInFixedTime(stateName, transitionDuration, layer, fixedTime);
        }

        public void CrossFadeInFixedTime(string stateName, float transitionDuration, int layer, float fixedTime)
        {
            this.CrossFadeInFixedTime(Animator.StringToHash(stateName), transitionDuration, layer, fixedTime);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CrossFadeInFixedTime(int stateNameHash, float transitionDuration, int layer, float fixedTime);

        public void CrossFadeInFixedTime(int stateNameHash, float transitionDuration, int layer)
        {
            float fixedTime = 0f;
            this.CrossFadeInFixedTime(stateNameHash, transitionDuration, layer, fixedTime);
        }

        public void CrossFadeInFixedTime(int stateNameHash, float transitionDuration)
        {
            float fixedTime = 0f;
            int layer = -1;
            this.CrossFadeInFixedTime(stateNameHash, transitionDuration, layer, fixedTime);
        }

        public void CrossFade(string stateName, float transitionDuration, int layer)
        {
            float normalizedTime = float.NegativeInfinity;
            this.CrossFade(stateName, transitionDuration, layer, normalizedTime);
        }

        public void CrossFade(string stateName, float transitionDuration)
        {
            float normalizedTime = float.NegativeInfinity;
            int layer = -1;
            this.CrossFade(stateName, transitionDuration, layer, normalizedTime);
        }

        public void CrossFade(string stateName, float transitionDuration,  int layer, float normalizedTime)
        {
            this.CrossFade(Animator.StringToHash(stateName), transitionDuration, layer, normalizedTime);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CrossFade(int stateNameHash, float transitionDuration, int layer, float normalizedTime);

        public void CrossFade(int stateNameHash, float transitionDuration, int layer)
        {
            float normalizedTime = float.NegativeInfinity;
            this.CrossFade(stateNameHash, transitionDuration, layer, normalizedTime);
        }

        public void CrossFade(int stateNameHash, float transitionDuration)
        {
            float normalizedTime = float.NegativeInfinity;
            int layer = -1;
            this.CrossFade(stateNameHash, transitionDuration, layer, normalizedTime);
        }

        public void PlayInFixedTime(string stateName, int layer)
        {
            float fixedTime = float.NegativeInfinity;
            this.PlayInFixedTime(stateName, layer, fixedTime);
        }

        public void PlayInFixedTime(string stateName)
        {
            float fixedTime = float.NegativeInfinity;
            int layer = -1;
            this.PlayInFixedTime(stateName, layer, fixedTime);
        }

        public void PlayInFixedTime(string stateName, int layer, float fixedTime)
        {
            this.PlayInFixedTime(Animator.StringToHash(stateName), layer, fixedTime);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void PlayInFixedTime(int stateNameHash, int layer, float fixedTime);

        public void PlayInFixedTime(int stateNameHash, int layer)
        {
            float fixedTime = float.NegativeInfinity;
            this.PlayInFixedTime(stateNameHash, layer, fixedTime);
        }

        public void PlayInFixedTime(int stateNameHash)
        {
            float fixedTime = float.NegativeInfinity;
            int layer = -1;
            this.PlayInFixedTime(stateNameHash, layer, fixedTime);
        }

        public void Play(string stateName, int layer)
        {
            float normalizedTime = float.NegativeInfinity;
            this.Play(stateName, layer, normalizedTime);
        }

        public void Play(string stateName)
        {
            float normalizedTime = float.NegativeInfinity;
            int layer = -1;
            this.Play(stateName, layer, normalizedTime);
        }

        public void Play(string stateName, int layer, float normalizedTime)
        {
            this.Play(Animator.StringToHash(stateName), layer, normalizedTime);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Play(int stateNameHash, int layer, float normalizedTime);

        public void Play(int stateNameHash, int layer)
        {
            float normalizedTime = float.NegativeInfinity;
            this.Play(stateNameHash, layer, normalizedTime);
        }

        public void Play(int stateNameHash)
        {
            float normalizedTime = float.NegativeInfinity;
            int layer = -1;
            this.Play(stateNameHash, layer, normalizedTime);
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_targetPosition(out Vector3 value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void INTERNAL_get_targetRotation(out Quaternion value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool IsControlled(Transform transform);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern bool IsBoneTransform(Transform transform);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern Transform GetBoneTransformInternal(int humanBoneId);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StartPlayback();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StopPlayback();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StartRecording(int frameCount);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StopRecording();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void ClearInternalControllerPlayable();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool HasState(int layerIndex, int stateID);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int StringToHash(string name);


        private void CheckIfInIKPass()
        {
            if (this.logWarnings && !this.CheckIfInIKPassInternal())
            {
                Debug.LogWarning("Setting and getting Body Position/Rotation, IK Goals, Lookat and BoneLocalRotation should only be done in OnAnimatorIK or OnStateIK");
            }
        }

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool CheckIfInIKPassInternal();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetFloatString(string name, float value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetFloatID(int id, float value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern float GetFloatString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern float GetFloatID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetBoolString(string name, bool value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetBoolID(int id, bool value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool GetBoolString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool GetBoolID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetIntegerString(string name, int value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetIntegerID(int id, int value);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int GetIntegerString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int GetIntegerID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetTriggerString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetTriggerID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void ResetTriggerString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void ResetTriggerID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool IsParameterControlledByCurveString(string name);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern bool IsParameterControlledByCurveID(int id);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetFloatStringDamp(string name, float value, float dampTime, float deltaTime);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void SetFloatIDDamp(int id, float value, float dampTime, float deltaTime);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void OnUpdateModeChanged();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void OnCullingModeChanged();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void WriteDefaultPose();

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Update(float deltaTime);

        
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Rebind();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void ApplyBuiltinRootMotion();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void EvaluateController();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern string GetCurrentStateName(int layerIndex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern string GetNextStateName(int layerIndex);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern string ResolveHash(int hash);
        
    }
}