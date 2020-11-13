using UnityEngine;

namespace SignalBehaviours.CustomSignals
{
    
    [CreateAssetMenu(fileName = "SquareWaveSignal", menuName = "Signal/SquareWaveSignal")]
    public class SquareWaveSignal : Signal
    {
        private const float STEP_THRESHOLD = 0;
        private const float PERIOD = 2 * Mathf.PI;

        [SerializeField]
        private float _frequency = 1;
        
        public override float GetValue(float time)
        {
            return Mathf.Sin(time * _frequency * PERIOD) > STEP_THRESHOLD
                ? 1
                : 0;
        }
        
    }
}
