using System;
using UnityEngine;

namespace SignalBehaviours
{
    
    /// <summary>
    /// Приемник сигнала, изменяющегося во времени,
    /// содержит хук для удобной обработки значения сигнала
    /// </summary>
    public abstract class ContinuousSignalAcceptor : SignalAcceptor
    {
        private void Update()
        {
            if (!_signalTransmitting)
                return;
            
            ProcessSignal(_signal.GetValue(Time.time - _startTransmittingTime));
        }

        protected abstract void ProcessSignal(float signalValue);
    }
}
