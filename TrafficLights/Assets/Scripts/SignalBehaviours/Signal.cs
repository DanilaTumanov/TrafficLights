using UnityEngine;

namespace SignalBehaviours
{
    public abstract class Signal : ScriptableObject, ISignal
    {

        public abstract float GetValue(float time);

    }
}
