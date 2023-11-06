using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour, IListener
{
    public SpawnerControllerStats Stats => stats;
    public int EnemiesLeftUntilBoss => _enemiesLeftUntilBoss;
    
    private Vector3 _screenSpace;
    
    [SerializeField] private List<EnemySpawner> enemySpawners;
    [SerializeField] private ObstacleSpawner[] obstacleSpawners;
    [SerializeField] private List<EnemySpawner> bossSpawners;

    [SerializeField] private SpawnerControllerStats stats;
    
    private float _creationCooldown;
    private float _creationTime;

    private int _currentDifficulty;

    private int _enemiesLeftUntilBoss;
    private bool _isBossSpawned;

    private int _enemiesCounter;
    
    void Start()
    {
        _screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        EnemySpawner[] spawnersNoFilter= GetComponentsInChildren<EnemySpawner>();
        for (int i = 0; i < spawnersNoFilter.Length; i++)
        {
            if (spawnersNoFilter[i].EnemyTypeToCreate is not Boss)
            {
                enemySpawners.Add(spawnersNoFilter[i]);
            }

            if (spawnersNoFilter[i].EnemyTypeToCreate is Boss)
            {
                bossSpawners.Add(spawnersNoFilter[i]);
            }
        }
        obstacleSpawners = GetComponentsInChildren<ObstacleSpawner>();
        
        _creationCooldown = stats.StartingCreationCooldown;
        _creationTime = _creationCooldown;
        _enemiesLeftUntilBoss = stats.EnemiesBetweenBosses;

        _currentDifficulty = stats.StartingDifficulty;
        
        EventManager.Instance.AddListener(EventConstants.EnemyDeath, this);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
    }

    void Update()
    {
        _creationTime -= Time.deltaTime;
        
        if(enemySpawners != null)
            SpawnEnemy();

        /* Crashea - Arreglalo o no lo dejes activo toadagarrandoselacabeza.jpg
        if(obstacleSpawners != null)
            SpawnObstacle();
        if(bossSpawners != null)
            SpawnBoss();
        */
    }

    private void SpawnEnemy()
    {
        if (_creationTime < 0 && _enemiesLeftUntilBoss != 0 && !_isBossSpawned)
        {
            if (enemySpawners.Count >= _currentDifficulty)
            {
                int ran = Random.Range(0, _currentDifficulty);
                enemySpawners[ran].Spawn();
                _creationTime = _creationCooldown;
                _enemiesCounter++;
                EventManager.Instance.DispatchSimpleEvent(EventConstants.EnemySpawned);
                RandomlyChangePosition();
            }
        }
    }

    private void SpawnObstacle()
    {
        if (_enemiesCounter >= stats.EnemiesUntilObstacles)
        {
            if(_currentDifficulty < enemySpawners.Count) _currentDifficulty++;
            int ranA = Random.Range(0, 100);
            if (ranA <= stats.ObstacleChancePercentage)
            {
                SetPosition(6.5f);
                int ranB = Random.Range(0, obstacleSpawners.Length);
                obstacleSpawners[ranB].Spawn();
                _enemiesCounter = 0;
            }
        }
    }

    private void SpawnBoss()
    {
        if (_enemiesLeftUntilBoss == 0 && !_isBossSpawned)
        {
            SetPosition(0);
            int ran = Random.Range(0, bossSpawners.Count);
            bossSpawners[ran].Spawn();
            _creationCooldown -= stats.CreationCooldownDecreasePerBoss;
            _isBossSpawned = true;
        }
    }

    void SetPosition(float yPos)
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
    
    void RandomlyChangePosition()
    {
        var ran = Random.Range(-_screenSpace.y, _screenSpace.y);
        transform.position = new Vector3(transform.position.x, ran, transform.position.z);
    }

    public void OnEventDispatch(string invokedEvent)
    {
        switch (invokedEvent)
        {
            case EventConstants.EnemyDeath:
                _enemiesLeftUntilBoss--;
                break;
            case EventConstants.BossDeath:
                if(_creationCooldown > stats.CreationCooldownDecreasePerBoss) _creationCooldown -= stats.CreationCooldownDecreasePerBoss;
                _isBossSpawned = false;
                _enemiesLeftUntilBoss = stats.EnemiesBetweenBosses;
                break;
        }
    }
}
