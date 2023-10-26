using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor, IMoveable, IPoolable
{
    public GameObject GameObject => this.gameObject;

    public float Speed => ActorStats.MovementSpeed;
    
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => cmdMoveLeft;
    public CmdMove CmdMoveRight => cmdMoveRight;
    public CmdMove CmdMoveUp => cmdMoveUp;
    public CmdMove CmdMoveDown => cmdMoveDown;

    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;

    private void Start()
    {
        InitializeCommands();
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed);
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, ActorStats.MovementSpeed);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, ActorStats.MovementSpeed);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, ActorStats.MovementSpeed);
    }

    public abstract void Move();

    public void OnPoolableObjectDisable()
    {
        gameObject.SetActive(false);
    }
    
    public IProduct Clone()
    {
        return Instantiate(this);
    }

}
