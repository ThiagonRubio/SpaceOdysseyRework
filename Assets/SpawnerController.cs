using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private Vector3 _screenSpace;
    
    [SerializeField] private EnemySpawner[] _spawners;

    [SerializeField] private float creationCooldown;
    private float creationTime;
    
    void Start()
    {
        _screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
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
            ChangePosition();
        }
    }

    void ChangePosition()
    {
        var ran = Random.Range(-_screenSpace.y, _screenSpace.y);
        transform.position = new Vector3(transform.position.x, ran, transform.position.z);
    }
}
