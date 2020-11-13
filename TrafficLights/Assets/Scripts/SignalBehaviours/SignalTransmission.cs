using System;
using UnityEngine;

namespace SignalBehaviours
{
    
    [Serializable]
    public class SignalTransmission
    {
        [SerializeField]
        private string _name;
        
        [SerializeField] 
        private Signal _signal;

        [SerializeField] 
        private SignalAcceptor _acceptor;
        

        public void Start()
        {
            _acceptor.SetSignal(_signal);
        }

        public void Stop()
        {
            _acceptor.RemoveSignal();
        }
    }
}
