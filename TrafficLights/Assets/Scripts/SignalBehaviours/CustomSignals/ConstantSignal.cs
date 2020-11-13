    using UnityEngine;

    namespace SignalBehaviours.CustomSignals
{
    
    [CreateAssetMenu(fileName = "ConstantSignal", menuName = "Signal/ConstantSignal")]
    public class ConstantSignal : Signal
    {
        
        public override float GetValue(float time)
        {
            return 1;
        }
        
    }
}
