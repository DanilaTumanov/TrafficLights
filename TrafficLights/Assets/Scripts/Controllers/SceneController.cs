using System;
using System.Collections.Generic;
using System.Linq;
using Selectors;
using Selectors.CustomSelectors;
using SignalBehaviours;
using UI.Controllers;
using UnityEngine;

namespace Controllers
{
    
    /// <summary>
    /// Основной контроллер, отвечающий за глобальную логику сцены.
    /// В нашем случае на сцена демонстрирует работу светофоров,
    /// поэтому контроллер содержит информацию о светофорах и о
    /// контроллере HUD, который предоставляет API для UI
    /// </summary>
    public class SceneController : MonoBehaviour
    {

        [SerializeField]
        private HUDController _hudController;

        [SerializeField]
        private SelectionController _selectionController;

        [SerializeField]
        private List<ImpactSelector> _trafficLights;


        private ImpactSelector _activeTrafficLights;


        private void Start()
        {
            _hudController.SetLights(
            _trafficLights
                .Select(tl => tl.Name)
                .ToArray()
            );
            
            _trafficLights.ForEach(tl => tl.gameObject.SetActive(false));

            _hudController.OnLightSelected += TrafficLightSelectHandler;
            
            _selectionController.SetSelectionSource(_hudController.ImpactSelectionSource);
        }

        private void TrafficLightSelectHandler(int index)
        {
            if (_activeTrafficLights != null)
            {
                _activeTrafficLights.gameObject.SetActive(false);
            }
            
            _activeTrafficLights = _trafficLights[index];
            _activeTrafficLights.gameObject.SetActive(true);
            _activeTrafficLights.Reset();
            
            _selectionController.SetSelector(_activeTrafficLights);
            
            _hudController.SetImpacts(
            _activeTrafficLights.ImpactList
                .Select(impact => impact.Name)
                .ToArray()
            );
        }
    }
}
