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

    //------PRIVATE PROPERTIES-------
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;
    
    private int _rotationSpeed;
    [SerializeField] private int rotationSpeedMin;
    [SerializeField] private int rotationSpeedMax;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

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

    private void OnBecameInvisible()
    {
        OnPoolableObjectDisable();
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate);
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate);
    }
    
    private void DefineRotation()
    {
        int _rotationDirection = Random.Range(1, 3);
        _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        if (_rotationDirection == 1) _rotationSpeed = -_rotationSpeed;
    }
    
    public void Move()
    {
        EntityCommandEventQueue.AddCommandToQueue(new CmdMove(entityRb, -transform.right, Speed, CmdMove.MoveType.Translate), 
            CommandEventQueue.UpdateFilter.Fixed);
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }

    public override void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        Debug.Log("Me pegaron lpm, me queda " + _actualHealth + " hp. Saludos.");

        if (_actualHealth <= 0)
            Die();
    }

    public override void Die()
    {
        OnPoolableObjectDisable();
    }

    public override void Revive()
    {
        throw new NotImplementedException();
    }

}
