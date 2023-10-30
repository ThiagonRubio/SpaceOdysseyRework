using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private float creationTime = 5;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Start()
    {
        enemyPool = GetComponent<ObjectPool>();
        enemyFactory = new EnemyFactory(this, enemyTypeToCreate, maxPoolSize);
    }

    private void Update()
    {
        //No se como es la logica de spawneo original asi que te regalo esto y despues lo cambias vos. Saludines.
        creationTime -= Time.deltaTime;

        if (creationTime < 0)
        {
            enemyFactory.CreateObject(this);
            creationTime = 5;
        }
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################


}
