using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMovement : Actor, IMoveable
{
    public float Speed => ActorStats.MovementSpeed;
    
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => _cmdMoveLeft;
    public CmdMove CmdMoveRight => _cmdMoveRight;
    public CmdMove CmdMoveUp => _cmdMoveUp;
    public CmdMove CmdMoveDown => _cmdMoveDown;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;

    private void Start()
    {
        InitializeCommands();
    }

    void Update()
    {
        Move();
    }
    
    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
    }
    
    public void Move()
    {
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        EntityCommandEventQueue.AddCommandToQueue(_cmdMoveLeft, CommandEventQueue.UpdateFilter.Normal);
    }
}
