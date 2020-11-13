using System;
using UnityEngine;

namespace SignalBehaviours
{
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
