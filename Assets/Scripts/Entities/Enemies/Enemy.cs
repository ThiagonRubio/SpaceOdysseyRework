using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IDamageable, IPoolable, IListener
{
    public GameObject GameObject => this.gameObject;
    
    public float MaxHealth => ActorStats.MaxHealth;
    public float ActualHealth => _actualHealth;

    public float ScoreGiven => scoreGiven;
    
    protected float _actualHealth;

    [SerializeField] protected float scoreGiven;
    
    protected virtual void Start()
    {
        _actualHealth = MaxHealth;
       
        //Suscripción a eventos
        EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
    }

    public abstract void TakeDamage(float damageAmount);

    public abstract void Die();
    
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
