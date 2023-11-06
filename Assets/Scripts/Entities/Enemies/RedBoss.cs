using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : Boss, IMoveable, IAttacker
{
    public float Speed => ActorStats.MovementSpeed;
    
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => cmdMoveLeft;
    public CmdMove CmdMoveRight => cmdMoveRight;
    public CmdMove CmdMoveUp => cmdMoveUp;
    public CmdMove CmdMoveDown => cmdMoveDown;
    public CmdAttack CmdAttack => cmdAttack;

    public IWeapon[] Weapon => _weapons;
    public float AttackCooldownTimer => attackCooldownTimer;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;
    private CmdAttack cmdAttack;


    private IWeapon[] _weapons;
    private float attackCooldownTimer = 0;
    [SerializeField] private float crashDamage;

    [SerializeField] private float xPos;
    
    void Start()
    {
        base.Start();
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        InitializeCommands();
    }

    void Update()
    {
        if (transform.position.x > xPos)
        {
            Move();
        }
        
        attackCooldownTimer += Time.deltaTime;
        if(attackCooldownTimer >= Weapon[0].FireRate) Attack();
    }
    
    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate);
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate);

        cmdAttack = new CmdAttack(Weapon);
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
        _entityCommandEventQueue.AddCommandToQueue(CmdAttack, CommandEventQueue.UpdateFilter.Fixed);
    }
    
    public override void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        if(_actualHealth <= 0)
            Die();
    }

    public override void Die()
    {
        EventManager.Instance.DispatchSimpleEvent(EventConstants.BossDeath);
        OnPoolableObjectDisable();
    }

    public override void Revive()
    {
        throw new System.NotImplementedException();
    }
}