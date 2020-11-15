using System;

namespace Impacts
{
    
    /// <summary>
    /// Воздействие на объект, содержит несколько атомарных действий,
    /// которые могут быть направлены на разные составляющие объекта.
    /// Является комплексным действием, и может использоваться в другом Impact
    /// </summary>
    /// <typeparam name="TImpactAction"></typeparam>
    [Serializable]
    public abstract class Impact<TImpactAction> : IImpactAction 
        where TImpactAction : IImpactAction
    {

        public abstract TImpactAction[] ActionList { get; }

        
        /// <summary>
        /// Применить воздействие
        /// </summary>
        public void Start()
        {
            foreach (var impactAction in ActionList)
            {
                impactAction.Start();
            }
        }

        /// <summary>
        /// Остановить воздействие
        /// </summary>
        public void Stop()
        {
            foreach (var impactAction in ActionList)
            {
                impactAction.Stop();
            }
        }
        
    }
}
