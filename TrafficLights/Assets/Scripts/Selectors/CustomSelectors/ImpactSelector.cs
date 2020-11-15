using Impacts.CustomImpacts;
using UnityEngine;

namespace Selectors.CustomSelectors
{
    
    /// <summary>
    /// Запускает воздействие, основываясь на индексе в списке
    /// </summary>
    public class ImpactSelector : MonoBehaviour, ISelector
    {
        
        [SerializeField]
        private string _name;
        
        [SerializeField]
        private SignalImpact[] _impactList;

        private int _selectedIndex = -1;


        public string Name => _name;

        public SignalImpact[] ImpactList => _impactList;
        
        
        public void Select(int index)
        {
            if (index >= _impactList.Length)
                return;

            if (_impactList[index] == null)
                return;

            Reset();

            _selectedIndex = index;
            _impactList[_selectedIndex].Start();
        }

        public void Reset()
        {
            if (_selectedIndex < 0)
                return;

            _impactList[_selectedIndex].Stop();
        }

    }
}
