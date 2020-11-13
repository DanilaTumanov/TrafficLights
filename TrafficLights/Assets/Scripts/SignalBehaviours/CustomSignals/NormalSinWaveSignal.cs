using UnityEngine;

namespace SignalBehaviours.CustomSignals
{
    
    [CreateAssetMenu(fileName = "NormalSinWaveSignal", menuName = "Signals/NormalSinWaveSignal")]
    public class NormalSinWaveSignal : Signal
    {
        private const float PERIOD = 2 * Mathf.PI;

        [SerializeField]
        private float _frequency = 1;
        
        [SerializeField]
        private float _offsetPeriod = 0;
        
        public override float GetValue(float time)
        {
            return Mathf.Sin((time + _offsetPeriod) * _frequency * PERIOD) / 2 + 0.5f;
        }
        
    }
}
