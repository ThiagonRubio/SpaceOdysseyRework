using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NebulaEffect : MonoBehaviour, IListener
{
    private Light2D _globalLight;
    
    private bool _isOn;

    private Obstacle _thisObstacle;
    
    void Start()
    {
        _globalLight = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();

        _thisObstacle = GetComponent<Obstacle>();
        
        EventManager.Instance.AddListener(EventConstants.NebulaActivation, this);
        EventManager.Instance.AddListener(EventConstants.NebulaDeactivation, this);
    }
    
    void Update()
    {
        if (_isOn)
        {
            _globalLight.intensity -= Time.deltaTime / 10;
            
            if (_globalLight.intensity <= 0.1)
                _globalLight.intensity = 0.1f;
        }

        if (!_isOn)
        {
            _globalLight.intensity += Time.deltaTime;
            
            if (_globalLight.intensity >= 1)
            {
                _globalLight.intensity = 1f;
            }
        }
    }

    private void OnBecameInvisible()
    {
        _thisObstacle.OnPoolableObjectDisable();
    }


    public void OnEventDispatch(string invokedEvent)
    {
        switch (invokedEvent)
        {
            case EventConstants.NebulaActivation:
                _isOn = true;
                break;
            case EventConstants.NebulaDeactivation:
                _isOn = false;
                break;
        }
    }
}
