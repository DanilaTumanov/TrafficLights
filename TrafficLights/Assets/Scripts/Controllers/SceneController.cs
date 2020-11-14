using System;
using System.Collections.Generic;
using System.Linq;
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
            _hudController.OnImpactSelected += ImpactSelectHandler;
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
            
            _hudController.SetImpacts(
            _activeTrafficLights.ImpactList
                .Select(impact => impact.Name)
                .ToArray()
            );
        }

        private void ImpactSelectHandler(int index)
        {
            _activeTrafficLights.Select(index);
        }
    }
}
