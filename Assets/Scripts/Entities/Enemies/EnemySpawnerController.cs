using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawnerController : MonoBehaviour, IListener
{
    private Vector3 _screenSpace;
    
    [SerializeField] private EnemySpawner[] spawners;
    [SerializeField] private EnemySpawner bossSpawner;
    
    [SerializeField] private float startingCreationCooldown;
    [SerializeField] private float creationCooldownDecreasePerBoss;
    private float _creationTime;

    [SerializeField] private int maxSpawnedAmount;
    private int _spawnedAmount;

    [SerializeField] private int difficulty;

    [SerializeField] private int enemiesBetweenBosses;
    private int _enemiesLeftTillBoss;
    private bool _isBossSpawned;
    
    void Start()
    {
        _screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        spawners = GetComponentsInChildren<EnemySpawner>();
        _creationTime = startingCreationCooldown;
        _enemiesLeftTillBoss = enemiesBetweenBosses;
        
        EventManager.Instance.AddListener(EventConstants.EnemyDeath, this);
        //EventManager.Instance.AddListener(EventConstants.BossDeath, this);
    }

    void Update()
    {
        _creationTime -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        if (_creationTime < 0 && _spawnedAmount < maxSpawnedAmount && _enemiesLeftTillBoss != 0 && !_isBossSpawned)
        {
            if (spawners.Length > difficulty)
            {
                int ran = Random.Range(0, difficulty);
                spawners[ran].Spawn();
                _spawnedAmount++;
                _creationTime = startingCreationCooldown;
                ChangePosition();
            }
        }
    }

    private void SpawnBoss()
    {
        if (_enemiesLeftTillBoss == 0 && !_isBossSpawned)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            bossSpawner.Spawn();
            startingCreationCooldown -= creationCooldownDecreasePerBoss;
            _isBossSpawned = true;

        }
    }
    
    void ChangePosition()
    {
        var ran = Random.Range(-_screenSpace.y, _screenSpace.y);
        transform.position = new Vector3(transform.position.x, ran, transform.position.z);
    }

    public void OnEventDispatch()
    {
        _spawnedAmount--;
        _enemiesLeftTillBoss--;
        
        SpawnEnemy();
        SpawnBoss();
    }
}
