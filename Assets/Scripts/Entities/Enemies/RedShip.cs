using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShip : Enemy, IMoveable, IAttacker
{
    public float Speed => ActorStats.MovementSpeed;

    public IWeapon[] Weapon => _weapons;
    public float AttackCooldownTimer => attackCooldownTimer;

    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => _cmdMoveLeft;
    public CmdMove CmdMoveRight => _cmdMoveRight;
    public CmdMove CmdMoveUp => _cmdMoveUp;
    public CmdMove CmdMoveDown => _cmdMoveDown;
    public CmdAttack CmdAttack => _cmdAttack;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;
    private CmdAttack _cmdAttack;

    private IWeapon[] _weapons;
    private float attackCooldownTimer = 0;
    [SerializeField] private float crashDamage;
    
    protected override void Start()
    {
        base.Start();
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        InitializeCommands();
    }

    private void Update()
    {
        Move();

        attackCooldownTimer += Time.deltaTime;
        if(attackCooldownTimer >= Weapon[0].FireRate) Attack();
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
            Die();
        }
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate);
        _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate);
        _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate);
        _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate);

        _cmdAttack = new CmdAttack(Weapon);
    }

    public void Move()
    {
        EntityCommandEventQueue.AddCommandToQueue(CmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
    }
    
    public void SetWeaponToUse(IWeapon[] weaponsToUse)
    {
        _weapons = weaponsToUse;
    }
    public void Attack()
    {
        attackCooldownTimer = 0;
        _entityCommandEventQueue.AddCommandToQueue(CmdAttack, CommandEventQueue.UpdateFilter.Normal);
    }
    
    public override void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        if(_actualHealth <= 0)
            Die();
    }

    public override void Die()
    {
        EventManager.Instance.DispatchSimpleEvent(EventConstants.EnemyDeath);
        OnPoolableObjectDisable();
    }

    public override void Revive()
    {
        throw new System.NotImplementedException();
    }
}
