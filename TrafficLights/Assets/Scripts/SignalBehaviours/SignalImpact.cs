using System;
using UnityEngine;

namespace SignalBehaviours
{
    
    /// <summary>
    /// Воздействие на объект, на основе сигналов,
    /// запускает одновременую передачу нескольких сигналов к разным приемникам,
    /// на основании настроек в инспекторе
    /// </summary>
    [Serializable]
    public class SignalImpact
    {

        [SerializeField]
        private string _name;
        
        [SerializeField] 
        private SignalTransmission[] _signalTransmissions;


        public string Name => _name;
        
        /// <summary>
        /// Применить воздействие
        /// </summary>
        public void Start()
        {
            foreach (var signalTransmission in _signalTransmissions)
            {
                signalTransmission.Start();
            }
        }

        /// <summary>
        /// Остановить воздействие
        /// </summary>
        public void Stop()
        {
            foreach (var signalTransmission in _signalTransmissions)
            {
                signalTransmission.Stop();
            }
        }
        
    }
}
