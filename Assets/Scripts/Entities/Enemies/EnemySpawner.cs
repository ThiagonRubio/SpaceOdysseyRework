using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class EnemySpawner : MonoBehaviour, IPoolOwner
{
    public GameObject GameObject => this.gameObject;

    public ObjectPool ObjectPool => enemyPool;

    public AbstractFactory<IPoolable> CreatorFactory => enemyFactory;

    //------PRIVATE PROPERTIES-------
    [SerializeField] private Enemy enemyTypeToCreate;
    [SerializeField] private int maxPoolSize = 1;

    private ObjectPool enemyPool;
    private EnemyFactory enemyFactory;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Start()
    {
        enemyPool = GetComponent<ObjectPool>();
        enemyFactory = new EnemyFactory(this, enemyTypeToCreate, maxPoolSize);
    }
    
    //################ #################
    //----------CLASS METHODS-----------
    //################ #################
    public void Spawn()
    {
        enemyFactory.CreateObject(this);
    }
}
