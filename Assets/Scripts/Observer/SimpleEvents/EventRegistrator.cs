using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script va a registrar todos los eventos para que no den error de no estar creados cuando alguien se quiera suscribir
public class EventRegistrator : MonoBehaviour 
{
    private void Awake()
    {
        EventManager.Instance.RegisterEvent(EventConstants.PlayerDeath);
        EventManager.Instance.RegisterEvent(EventConstants.EnemySpawned);
        EventManager.Instance.RegisterEvent(EventConstants.EnemyDeath);
        EventManager.Instance.RegisterEvent(EventConstants.BossDeath);
        
        EventManager.Instance.RegisterEvent(EventConstants.NukeEffect);
        EventManager.Instance.RegisterEvent(EventConstants.ShieldEffect);
        EventManager.Instance.RegisterEvent(EventConstants.DoubleTapEffect);
        EventManager.Instance.RegisterEvent(EventConstants.TripleShotEffect);
        
        EventManager.Instance.RegisterEvent(EventConstants.NebulaActivation);
        EventManager.Instance.RegisterEvent(EventConstants.NebulaDeactivation);
        
        EventManager.Instance.RegisterEvent(EventConstants.Won);
        EventManager.Instance.RegisterEvent(EventConstants.Lost);
        
        Destroy(gameObject);
    }
}
