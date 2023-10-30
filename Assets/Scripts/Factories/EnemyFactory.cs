using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractFactory<IPoolable>
{
    private readonly int maxPoolableEnemies = 1;

    //----CONSTRUCTOR----
    public EnemyFactory(IPoolOwner creator, Enemy enemyToCreate, int maxPoolableObjects) : base(enemyToCreate)
    {
        objectToCreate = enemyToCreate;
        this.maxPoolableEnemies = maxPoolableObjects;
        InitObjectPool(creator);
    }
    //----METHODS-----
    public void InitObjectPool(IPoolOwner creator)
    {
        Enemy enemyInCurrentPool = (Enemy)objectToCreate;
        creator.ObjectPool.CreatePool(enemyInCurrentPool, maxPoolableEnemies);
    }
    public override IPoolable CreateObject()
    {
        return (Enemy)objectToCreate.Clone();
    }
    public Enemy CreateObject(IPoolOwner creator)
    {
        return (Enemy)creator.ObjectPool.TryGetPooledObject();
    }
}
