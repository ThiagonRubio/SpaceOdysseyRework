using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRegistrator : MonoBehaviour 
    //Este script va a registrar todos los eventos para que no den error de no estar creados cuando alguien se quiera suscribir

    //porque lo hiciste singleton lpm estuve 1 hora hasta que llegue hasta esto que estaba escondido y sin usar, con razon no te
    //andaba ningun evento toadagarrandoselacabeza.jpg
{
    private void Awake()
    {
        EventManager.Instance.RegisterEvent(EventConstants.PlayerDeath);
        EventManager.Instance.RegisterEvent(EventConstants.EnemyDeath);
        EventManager.Instance.RegisterEvent(EventConstants.BossDeath);
        
        EventManager.Instance.RegisterEvent(EventConstants.NukeEffect);
        EventManager.Instance.RegisterEvent(EventConstants.ShieldEffect);
        EventManager.Instance.RegisterEvent(EventConstants.DoubleTapEffect);
        EventManager.Instance.RegisterEvent(EventConstants.TripleShotEffect);
        
        Destroy(gameObject);
    }
}
