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

    public bool CanDie => canDie;
    
    protected float _actualHealth;

    protected float randomAttackTime = 0;
    protected bool canAttack = false;

    [SerializeField] protected float scoreGiven;
    private bool canDie;
    protected virtual void Start()
    {
        _actualHealth = MaxHealth;
        randomAttackTime = UnityEngine.Random.Range(0.1f, 0.4f);

        canDie = true;
        
        //Suscripción a eventos
        if(this as Boss == false)
            EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
        EventManager.Instance.AddListener(EventConstants.Lost, this);
    }
    protected virtual void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventConstants.NukeEffect, this);
        EventManager.Instance.RemoveListener(EventConstants.Lost, this);
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
        if (invokedEvent == EventConstants.Lost)
            canDie = false;
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }
}
