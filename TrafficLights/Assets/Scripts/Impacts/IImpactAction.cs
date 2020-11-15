using UnityEngine;

namespace Impacts
{
    
    /// <summary>
    /// Атомарное действие, набор которых использует Impact
    /// </summary>
    public interface IImpactAction
    {

        void Start();
        void Stop();

    }
}
