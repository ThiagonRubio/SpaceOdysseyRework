using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IDamageable, IPoolable, IListener
{
    public GameObject GameObject => this.gameObject;
    
    public float MaxHealth => ActorStats.MaxHealth;
    public float ActualHealth => _actualHealth;

    protected float _actualHealth;
    
    protected virtual void Start()
    {
        _actualHealth = MaxHealth;
       
        //Suscripción a eventos
        EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
    }

    public abstract void TakeDamage(float damageAmount);

    public abstract void Die();

    public abstract void Revive();
    
    public void OnPoolableObjectDisable()
    {
        _actualHealth = MaxHealth;
        gameObject.SetActive(false);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.NukeEffect)
            Die();
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }
}
