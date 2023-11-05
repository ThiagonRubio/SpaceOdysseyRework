using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : AbstractFactory<IPoolable>
{
    private readonly int maxPoolableEnemies = 1;

    public ObstacleFactory(IPoolOwner creator, Obstacle obstacleToCreate, int maxPoolableEnemies) : base(obstacleToCreate)
    {
        objectToCreate = obstacleToCreate;
        this.maxPoolableEnemies = maxPoolableEnemies;
        InitObjectPool(creator);
    }

    public void InitObjectPool(IPoolOwner creator)
    {
        Obstacle obstacleInCurrentPool = (Obstacle)objectToCreate;
        creator.ObjectPool.CreatePool(obstacleInCurrentPool, maxPoolableEnemies);
    }
    
    public override IPoolable CreateObject()
    {
        return (Obstacle)objectToCreate.Clone();
    }
    public Obstacle CreateObject(IPoolOwner creator)
    {
        return (Obstacle)creator.ObjectPool.TryGetPooledObject();
    }
}
