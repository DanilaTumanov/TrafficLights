using SignalBehaviours;
using UnityEngine;

namespace TrafficLights
{
    
    public class LavaLight : SignalAcceptor
    {
    
        [SerializeField]
        [ColorUsage(true,true)]
        private Color _color;

        [SerializeField]
        private Renderer _renderer;

        private static readonly int Color = Shader.PropertyToID("_Color");
    

        protected override void Start()
        {
            SetColor(_color);

            base.Start();
        }


        protected override void OnSignalSet()
        {
            _renderer.enabled = true;
        }

        protected override void OnSignalRemove()
        {
            _renderer.enabled = false;
        }


        protected override void Reset()
        {
            _renderer.enabled = false;
        }

        private void SetColor(Color color)
        {
            var propBlock = new MaterialPropertyBlock();
            _renderer.GetPropertyBlock(propBlock);
            propBlock.SetColor(Color, color);
            _renderer.SetPropertyBlock(propBlock);
        }

    }
}
