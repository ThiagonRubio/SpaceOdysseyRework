using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _spawners;

    [SerializeField] private float creationCooldown;
    private float creationTime;
    
    void Start()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>();
        creationTime = creationCooldown;
    }

    void Update()
    {
        creationTime -= Time.deltaTime;
        if (creationTime < 0)
        {
            int ran = Random.Range(0, _spawners.Length);
            _spawners[ran].Spawn();
            creationTime = creationCooldown;
        }
    }
}
