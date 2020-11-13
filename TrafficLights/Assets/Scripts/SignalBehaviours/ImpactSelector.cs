using UnityEngine;

namespace SignalBehaviours
{
    public class ImpactSelector : MonoBehaviour
    {
        
        [SerializeField]
        private SignalImpact[] _impactList;

        private int _selectedIndex = -1;

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
