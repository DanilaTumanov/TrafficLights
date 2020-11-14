using UnityEngine;

namespace SignalBehaviours
{
    
    /// <summary>
    /// Реализация сигнала, настраиваемого в инспекторе
    /// </summary>
    public abstract class Signal : ScriptableObject, ISignal
    {

        public abstract float GetValue(float time);

    }
}
