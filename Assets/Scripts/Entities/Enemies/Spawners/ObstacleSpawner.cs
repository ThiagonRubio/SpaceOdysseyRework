using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour, IPoolOwner
{
    public GameObject GameObject => gameObject;

    public ObjectPool ObjectPool => _obstaclePool;

    public AbstractFactory<IPoolable> CreatorFactory => _obstacleFactory;

    public Obstacle ObstacleToCreate => obstacleToCreate;

    public float SpawnYPosition => spawnYPosition;
    
    [SerializeField] private Obstacle obstacleToCreate;
    [SerializeField] private int maxPoolSize = 1;

    [SerializeField] private float spawnYPosition;
    
    private ObjectPool _obstaclePool;
    private ObstacleFactory _obstacleFactory;

    private void Start()
    {
        _obstaclePool = GetComponent<ObjectPool>();
        _obstacleFactory = new ObstacleFactory(this, obstacleToCreate, maxPoolSize);
    }

    public void Spawn()
    {
        _obstacleFactory.CreateObject(this);
    }
}