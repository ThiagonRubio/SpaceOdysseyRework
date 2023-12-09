using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowShip : Enemy, IMoveable, IAttacker
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
    
    private Vector3 _screenSpace;
    private SpriteRenderer _sprite;
    private bool _isMovingUpwards;
    [SerializeField] private float verticalSpeed;
    
    protected override void Start()
    {
        base.Start();
        
        //Los necesito para que hacer que no se salga de la pantalla
        _screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _sprite = GetComponent<SpriteRenderer>();
        
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        
        InitializeCommands();
    }

    void Update()
    {
        Move();
        ChangeDirection();

        if (canAttack)
        {
            attackCooldownTimer += Time.deltaTime;
            if (attackCooldownTimer + randomAttackTime >= Weapon[0].FireRate) Attack();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<IDamageable>(out IDamageable damagedPlayer)) 
        {
            damagedPlayer.TakeDamage(crashDamage);
            EventManager.Instance.DispatchSimpleEvent(EventConstants.EnemyDeath);
            ActionsManager.InvokeAction(EventConstants.EnemyDeath, this.transform);
            Die();
        }
    }
    private void OnBecameVisible()
    {
        canAttack = true;
    }
    private void OnBecameInvisible()
    {
        canAttack = false;
        OnPoolableObjectDisable();
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        _cmdAttack = new CmdAttack(Weapon);
    }

    public void Move()
    {
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        EntityCommandEventQueue.AddCommandToQueue(_cmdMoveLeft, CommandEventQueue.UpdateFilter.Normal);
        
        if(_isMovingUpwards)
        {
            _cmdMoveUp = new CmdMove(entityRb, Vector2.up, verticalSpeed, CmdMove.MoveType.Translate, Time.deltaTime);
            EntityCommandEventQueue.AddCommandToQueue(_cmdMoveUp, CommandEventQueue.UpdateFilter.Normal);
        }
        else
        {
            _cmdMoveDown = new CmdMove(entityRb, Vector2.down, verticalSpeed, CmdMove.MoveType.Translate, Time.deltaTime);
            EntityCommandEventQueue.AddCommandToQueue(_cmdMoveDown, CommandEventQueue.UpdateFilter.Normal);
        }
    }

    private void ChangeDirection()
    {
        
        if (transform.position.y + (_sprite.sprite.rect.height / _sprite.sprite.pixelsPerUnit * transform.localScale.y / 2) >= _screenSpace.y)
        {
            _isMovingUpwards = false;
        }

        if (transform.position.y - (_sprite.sprite.rect.height / _sprite.sprite.pixelsPerUnit * transform.localScale.y / 2) <= -_screenSpace.y)
        {
            _isMovingUpwards = true;
        }
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
}
