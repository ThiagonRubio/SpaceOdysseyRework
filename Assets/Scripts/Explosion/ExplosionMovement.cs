using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMovement : Actor, IMoveable
{
    public float Speed => ActorStats.MovementSpeed;
    
    public CmdMove CmdMoveLeft => _cmdMoveLeft;
    public CmdMove CmdMoveRight => _cmdMoveRight;
    public CmdMove CmdMoveUp => _cmdMoveUp;
    public CmdMove CmdMoveDown => _cmdMoveDown;
    
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;

    private void Start()
    {
        SoundManager.Instance.ReproduceSound(AudioConstants.Explosion, 1);
    }

    void Update()
    {
        Move();
    }
    
    public void Move()
    {
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        CmdMoveLeft.Execute();
    }
}
