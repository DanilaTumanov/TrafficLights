using UnityEngine;

namespace SignalBehaviours.CustomSignals
{
    
    /// <summary>
    /// Нормализованный синусовый сигнал [0, 1]
    /// </summary>
    [CreateAssetMenu(fileName = "NormalSinWaveSignal", menuName = "Signals/NormalSinWaveSignal")]
    public class NormalSinWaveSignal : Signal
    {
        private const float PERIOD = 2 * Mathf.PI;

        [SerializeField]
        [Tooltip("Частота (сек^-1)")]
        private float _frequency = 1;
        
        [SerializeField]
        [Tooltip("Смещение входного параметра времени (сек)")]
        private float _offset = 0;
        
        public override float GetValue(float time)
        {
            return Mathf.Sin((time + _offset) * _frequency * PERIOD) / 2 + 0.5f;
        }
        
    }
}
