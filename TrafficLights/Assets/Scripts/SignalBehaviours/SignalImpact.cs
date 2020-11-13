using System;
using UnityEngine;

namespace SignalBehaviours
{
    
    [Serializable]
    public class SignalImpact
    {

        [SerializeField] 
        private SignalTransmission[] _signalTransmissions;
        
        
        public void Start()
        {
            foreach (var signalTransmission in _signalTransmissions)
            {
                signalTransmission.Start();
            }
        }

        public void Stop()
        {
            foreach (var signalTransmission in _signalTransmissions)
            {
                signalTransmission.Stop();
            }
        }
        
    }
}
