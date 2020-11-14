using UnityEngine;

namespace SignalBehaviours.CustomSignals
{
    
    /// <summary>
    /// Постоянный сигнал, всегда возвращает 1
    /// </summary>
    [CreateAssetMenu(fileName = "ConstantSignal", menuName = "Signal/ConstantSignal")]
    public class ConstantSignal : Signal
    {
        
        public override float GetValue(float time)
        {
            return 1;
        }
        
    }
}
