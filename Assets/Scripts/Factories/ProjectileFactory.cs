using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : AbstractFactory<IPoolable>
{
    private readonly int maxPoolableProjectiles = 1;

    //----CONSTRUCTOR----
    public ProjectileFactory(IPoolOwner creator, IProjectile projectileToCreate, int maxPoolableObjects) : base(projectileToCreate)
    {
        objectToCreate = projectileToCreate;
        this.maxPoolableProjectiles = maxPoolableObjects;
        InitObjectPool(creator);
    }
    //----METHODS-----
    public void InitObjectPool(IPoolOwner creator)
    {
        IProjectile projectileInCurrentPool = (IProjectile)objectToCreate;
        creator.ObjectPool.CreatePool(projectileInCurrentPool, maxPoolableProjectiles);
    }
    public override IPoolable CreateObject()
    {
        return (IProjectile)objectToCreate.Clone();
    }
    public IProjectile CreateObject(IPoolOwner creator)
    {
        return (IProjectile)creator.ObjectPool.TryGetPooledObject();
    }
}