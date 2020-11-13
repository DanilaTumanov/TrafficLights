using System;
using System.Collections;
using System.Collections.Generic;
using SignalBehaviours;
using UnityEngine;

public class TrafficLightsController : MonoBehaviour
{
    public ImpactSelector _trafficLights;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _trafficLights.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _trafficLights.Select(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _trafficLights.Select(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _trafficLights.Select(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _trafficLights.Select(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _trafficLights.Select(4);
        }
        
    }
}
