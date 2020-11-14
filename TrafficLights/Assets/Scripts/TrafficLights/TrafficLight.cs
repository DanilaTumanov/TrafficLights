using System;
using System.Runtime.CompilerServices;
using SignalBehaviours;
using UnityEngine;

namespace TrafficLights
{
    
    /// <summary>
    /// Светофорный световой сигнал (одна лампа)
    /// </summary>
    public class TrafficLight : ContinuousSignalAcceptor
    {
        private static readonly Color DISABLED_COLOR = Color.black;


        [SerializeField]
        private SpriteRenderer _sprite;

        private Color _initialColor;

        protected override void Start()
        {
            _initialColor = _sprite.color;
            
            base.Start();
        }

        protected override void Reset()
        {
            _sprite.color = DISABLED_COLOR;
        }

        protected override void OnSignalRemove()
        {
            Reset();
        }

        protected override void ProcessSignal(float signalValue)
        {
            Color.Lerp(Color.black, _initialColor, signalValue);
            _sprite.color = Color.Lerp(DISABLED_COLOR, _initialColor, signalValue);
        }
    }
}
