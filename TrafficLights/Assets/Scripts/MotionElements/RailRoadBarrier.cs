using System.Collections;
using SignalBehaviours;
using UnityEngine;

namespace MotionElements
{
    
    /// <summary>
    /// Шлагбаум железнодорожного переезда,
    /// управляется постоянным сигналом,
    /// реагирует только на подачу и снятие сигнала
    /// </summary>
    public class RailRoadBarrier : SignalAcceptor
    {
        [SerializeField]
        private Vector3 _openRotation;
        
        [SerializeField]
        private Vector3 _closeRotation;
        
        [SerializeField]
        private float _speed;


        private Quaternion _openQRotation;
        private Quaternion _closeQRotation;
        private Quaternion _initialRotation;


        protected override void Start()
        {
            _openQRotation = Quaternion.Euler(_openRotation);
            _closeQRotation = Quaternion.Euler(_closeRotation);
            
            base.Start();
        }

        protected override void Reset()
        {
            transform.rotation = _openQRotation;
        }

        protected override void OnSignalSet()
        {
            StartCoroutine(RotateTo(_closeQRotation));
        }
        
        protected override void OnSignalRemove()
        {
            StartCoroutine(RotateTo(_openQRotation));
        }

        private IEnumerator RotateTo(Quaternion destinationRotation)
        {
            float t = 0;
            var initialRotation = transform.rotation;
            while (t < 1)
            {
                transform.rotation = Quaternion.Slerp(initialRotation, destinationRotation, t);
                yield return null;
                t += Time.deltaTime * _speed;
            }

            transform.rotation = destinationRotation;
        }
    }
}
