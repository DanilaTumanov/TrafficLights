﻿using System;
using SignalBehaviours;
using UnityEngine;

namespace Impacts
{
    
    /// <summary>
    /// Передача сигнала к приемнику.
    /// При запуске делает ровно то, что следует из названия :)
    /// </summary>
    [Serializable]
    public class SignalTransmission : IImpactAction
    {
        [SerializeField]
        private string _name;
        
        [SerializeField] 
        private Signal _signal;

        [SerializeField] 
        private SignalAcceptor _acceptor;
        

        /// <summary>
        /// Запустить передачу сигнала
        /// </summary>
        public void Start()
        {
            _acceptor.SetSignal(_signal);
        }

        /// <summary>
        /// Остановить передачу сигнала
        /// </summary>
        public void Stop()
        {
            _acceptor.RemoveSignal();
        }
    }
}
