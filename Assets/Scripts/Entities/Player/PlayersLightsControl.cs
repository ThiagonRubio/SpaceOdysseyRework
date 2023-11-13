using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayersLightsControl : MonoBehaviour, IListener
{
    [SerializeField] private GameObject rocket1;
    [SerializeField] private GameObject rocket2;
    [SerializeField] private Light2D beacon;

    private bool _nebulaIsActivated;
    
    void Start()
    {
        EventManager.Instance.AddListener(EventConstants.NebulaActivation, this);
        EventManager.Instance.AddListener(EventConstants.NebulaDeactivation, this);
    }

    void Update()
    {
        if (_nebulaIsActivated)
        {
            beacon.intensity += Time.deltaTime / 10;
            if (beacon.intensity >= 1)
            {
                beacon.intensity = 1;
            }
        }

        if (!_nebulaIsActivated)
        {
            beacon.intensity -= Time.deltaTime / 10;
            if (beacon.intensity <= 0)
            {
                beacon.intensity = 0;
            }
        }
    }

    public void IsNotMoving()
    {
        rocket1.SetActive(false);
        rocket2.SetActive(false);
    }
    
    public void IsMoving()
    {
        rocket1.SetActive(true);
        rocket2.SetActive(true);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.NebulaActivation)
        {
            _nebulaIsActivated = true;
        }
        
        if (invokedEvent == EventConstants.NebulaDeactivation)
        {
            _nebulaIsActivated = false;
        }
    }
}
