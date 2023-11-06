using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpDropper : MonoBehaviour, IListener //Lo deberían tener los enemy
{
    [SerializeField] private GameObject[] powerUps;

    [SerializeField] private int dropChancePercentage;

    // private void Start()
    // {
    //     EventManager.Instance.AddListener(EventConstants.EnemyDeath,this);
    // }

    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.EnemyDeath)
        {
            int ranA = Random.Range(0, 100);
            if (ranA <= dropChancePercentage)
            {
                int ranB = Random.Range(0, powerUps.Length);
                Instantiate(powerUps[ranB], transform.position, Quaternion.identity);
            }
        }
    }
}
