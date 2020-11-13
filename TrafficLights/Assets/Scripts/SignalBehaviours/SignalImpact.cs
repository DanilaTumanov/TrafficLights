using System;
using UnityEngine;

namespace SignalBehaviours
{
    
    [Serializable]
    public class SignalImpact
    {

        [SerializeField]
        private string _name;
        
        [SerializeField] 
        private SignalTransmission[] _signalTransmissions;


        public string Name => _name;
        
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
