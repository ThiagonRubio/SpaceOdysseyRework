using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IDamageable, IMoveable, IPoolable
{
    public GameObject GameObject => this.gameObject;

    public float Speed => ActorStats.MovementSpeed;
    
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => cmdMoveLeft;
    public CmdMove CmdMoveRight => cmdMoveRight;
    public CmdMove CmdMoveUp => cmdMoveUp;
    public CmdMove CmdMoveDown => cmdMoveDown;

    public float MaxHealth => ActorStats.MaxHealth;
    public float ActualHealth => _actualHealth;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;

    private float _actualHealth;
    
    protected virtual void Start()
    {
        InitializeCommands();
        _actualHealth = MaxHealth;
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed);
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed);
    }

    public abstract void Move();

    public void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        if (ActualHealth <= 0)
        {
            //El die
        }
    }

    public void Die()
    {
        //Todo el comportamiento de pools 
    }

    public void Revive()
    {
        throw new NotImplementedException();
        //Esto técnicamente todavía no hace nada? Sería para memento I guess
    }
    
    public void OnPoolableObjectDisable()
    {
        gameObject.SetActive(false);
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }
}
