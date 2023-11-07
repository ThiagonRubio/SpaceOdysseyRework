using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpDropper : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;

    [SerializeField] private int dropChancePercentage;

    private void Start()
    {
        ActionsManager.SubscribeToAction(EventConstants.EnemyDeath, DropPowerUp);
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
