using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    [SerializeField] private float crashDamage;
    
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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<IDamageable>(out IDamageable damagedPlayer)) 
        {
            damagedPlayer.TakeDamage(crashDamage);
        }
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
    }
    
    private void DefineRotation()
    {
        int _rotationDirection = Random.Range(1, 3);
        _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        if (_rotationDirection == 1) _rotationSpeed = -_rotationSpeed;
    }
    
    public void Move()
    {
        cmdMoveLeft = new CmdMove(entityRb, -transform.right, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        EntityCommandEventQueue.AddCommandToQueue(cmdMoveLeft, CommandEventQueue.UpdateFilter.Normal);
    }

    public void Rotate()
    {
        gameObject.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }

    public override void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        entityAnim.SetTrigger(AnimationConstants.TookDamage);
        SoundManager.Instance.ReproduceSound(AudioConstants.TookDamage, 1);
        
        if (_actualHealth <= 0)
        {
            EventManager.Instance.DispatchSimpleEvent(EventConstants.EnemyDeath);
            ActionsManager.InvokeAction(EventConstants.EnemyDeath, this.transform);
            Die();
        }
    }

    public override void Die()
    {
        Instantiate(ActorStats.Explosion, transform.position, Quaternion.identity);
        OnPoolableObjectDisable();
    }
        

    public override void Revive()
    {
        throw new NotImplementedException();
    }

}
