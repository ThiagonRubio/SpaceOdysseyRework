using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IDamageable, IPoolable
{
    public GameObject GameObject => this.gameObject;

    
    

    public float MaxHealth => ActorStats.MaxHealth;
    public float ActualHealth => _actualHealth;

    private float _actualHealth;
    
    protected virtual void Start()
    {
        _actualHealth = MaxHealth;
    }

    public abstract void TakeDamage(float damageAmount);

    public abstract void Die();

    public abstract void Revive();
    
    public void OnPoolableObjectDisable()
    {
        gameObject.SetActive(false);
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }
}
