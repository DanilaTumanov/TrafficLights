using UnityEngine;

namespace SignalBehaviours
{
    public abstract class SignalAcceptor : MonoBehaviour
    {

        protected bool _signalTransmitting = false;
        protected float _startTransmittingTime;
        protected ISignal _signal;

        protected virtual void Start()
        {
            Reset();
        }

        public void SetSignal(ISignal signal)
        {
            _startTransmittingTime = Time.time;
            _signalTransmitting = true;
            _signal = signal;
            OnSignalSet();
        }

        public void RemoveSignal()
        {
            OnSignalRemove();
            _signalTransmitting = false;
            _signal = null;
        }


        protected virtual void OnSignalSet() {}
        
        protected virtual void OnSignalRemove() {}
        
        protected abstract void Reset();

    }
}
