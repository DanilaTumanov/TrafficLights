using System;
using Selectors;
using TMPro;
using UI.IndexSelector;
using UnityEngine;

namespace UI.Controllers
{
    
    /// <summary>
    /// Контроллер HUD,
    /// Реализует API для взаимодействия с пользователем
    /// </summary>
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


        private string[] _lightsNames;
        private string[] _impactsNames;


        public ISelectionSource ImpactSelectionSource => _impactSelector;
        
        
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
            _lightsNames = names;
            _lightSelector.Reset(names);
        }

        public void SetImpacts(string[] names)
        {
            _impactsNames = names;
            _impactSelector.Reset(names);
        }


        private void LightSelectHandler(int index)
        {
            OnLightSelected?.Invoke(index);
            _selectedTrafficLightsName.text = _lightsNames[index];
            _selectedModeName.text = String.Empty;
        }

        private void ImpactSelectHandler(int index)
        {
            OnImpactSelected?.Invoke(index);
            _selectedModeName.text = _impactsNames[index];
        }
        
    }
}
