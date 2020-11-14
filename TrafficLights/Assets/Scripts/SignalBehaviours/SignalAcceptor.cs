using UnityEngine;

namespace SignalBehaviours
{
    
    /// <summary>
    /// Приемник сигнала,
    /// содержит хуки для удобного отслеживания подачи и снятия сигнала
    /// </summary>
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


        /// <summary>
        /// Срабатывает при подаче сигнала
        /// </summary>
        protected virtual void OnSignalSet() {}
        
        /// <summary>
        /// Срабатывает при снятии сигнала
        /// </summary>
        protected virtual void OnSignalRemove() {}
        
        /// <summary>
        /// Сброс состояния приемника (автоматически вызывается на старте)
        /// </summary>
        protected abstract void Reset();

    }
}
