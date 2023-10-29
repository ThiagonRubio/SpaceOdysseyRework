using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Asteroid : Enemy, IRotable, IMoveable
{
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => cmdMoveLeft;
    public CmdMove CmdMoveRight => cmdMoveRight;
    public CmdMove CmdMoveUp => cmdMoveUp;
    public CmdMove CmdMoveDown => cmdMoveDown;
    
    public float Speed => ActorStats.MovementSpeed;
    public int RotationSpeed => _rotationSpeed;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;
    
    private int _rotationSpeed;
    [SerializeField] private int rotationSpeedMin;
    [SerializeField] private int rotationSpeedMax;
    
    protected override void Start()
    {
        base.Start();
        InitializeCommands();
        DefineRotation();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed);
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed);
    }
    
    private void DefineRotation()
    {
        int _rotationDirection = Random.Range(1, 3);
        _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        if (_rotationDirection == 1) _rotationSpeed = -_rotationSpeed;
    }
    
    public void Move()
    {
        EntityCommandEventQueue.AddCommandToQueue(new CmdMove(entityRb, -transform.right, Speed), CommandEventQueue.UpdateFilter.Fixed);
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }

    public override void TakeDamage(float damageAmount)
    {
        Debug.Log("Me pegaron lpm");
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void Revive()
    {
        throw new NotImplementedException();
    }

}
