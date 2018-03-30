using System;

namespace AbsUnity
{
    public interface ISerializationCallbackReceiver
    {
        void OnBeforeSerialize();

        void OnAfterDeserialize();
    }
}
