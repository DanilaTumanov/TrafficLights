using System;
using TMPro;
using UI.IndexSelector;
using UnityEngine;

namespace UI.Controllers
{
    public class HUDController : MonoBehaviour
    {

        [SerializeField]
        private Selector _lightSelector;

        [SerializeField]
        private Selector _impactSelector;

        [SerializeField]
        private TMP_Text _selectedTrafficLightsName;

        [SerializeField]
        private TMP_Text _selectedModeName;


        public event Action<int> OnLightSelected;
        public event Action<int> OnImpactSelected;


        private void Awake()
        {
            _lightSelector.OnSelect += LightSelectHandler;
            _impactSelector.OnSelect += ImpactSelectHandler;
            
            _selectedTrafficLightsName.text = String.Empty;
            _selectedModeName.text = String.Empty;
        }


        public void SetLights(string[] names)
        {
            _lightSelector.Reset(names);
        }

        public void SetImpacts(string[] names)
        {
            _impactSelector.Reset(names);
        }


        private void LightSelectHandler(int index, string name)
        {
            OnLightSelected?.Invoke(index);
            _selectedTrafficLightsName.text = name;
            _selectedModeName.text = String.Empty;
        }

        private void ImpactSelectHandler(int index, string name)
        {
            OnImpactSelected?.Invoke(index);
            _selectedModeName.text = name;
        }
        
    }
}
