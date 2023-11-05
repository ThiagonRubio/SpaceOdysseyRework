using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUpDropper : MonoBehaviour, IListener //Lo deberían tener los enemy
{
    [SerializeField] private GameObject[] powerUps;

    [SerializeField] private int dropChancePercentage;
    
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
