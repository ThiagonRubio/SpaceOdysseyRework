using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpDropper : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;

    [SerializeField] private int dropChancePercentage;

    private void OnEnable()
    {
        ActionsManager.SubscribeToAction(EventConstants.EnemyDeath, DropPowerUp);
    }
    private void OnDisable()
    {
        ActionsManager.UnsubscribeToAction(EventConstants.EnemyDeath, DropPowerUp);
    }

    public void DropPowerUp(Transform transformReceived)
    {  
        int ranA = Random.Range(0, 100);
        if (ranA <= dropChancePercentage)
        {
            int ranB = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[ranB], transformReceived.position, Quaternion.identity);
        }
    }
}
