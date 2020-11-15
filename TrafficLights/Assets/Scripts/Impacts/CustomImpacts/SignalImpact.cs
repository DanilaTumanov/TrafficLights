using System;
using UnityEngine;

namespace Impacts.CustomImpacts
{
    
    /// <summary>
    /// Воздействие на объект, на основе сигналов,
    /// запускает одновременую передачу нескольких сигналов к разным приемникам,
    /// на основании настроек в инспекторе
    /// </summary>
    [Serializable]
    public class SignalImpact : Impact<SignalTransmission>
    {
        [SerializeField]
        private string _name;

        [SerializeField] 
        private SignalTransmission[] _signalTransmissions;
        

        public string Name => _name;

        public override SignalTransmission[] ActionList => _signalTransmissions;
        
    }
}
