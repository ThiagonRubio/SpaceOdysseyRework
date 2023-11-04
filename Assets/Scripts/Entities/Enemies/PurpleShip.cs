using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleShip : Enemy, IMoveable, IAttacker
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
    private bool _isMovingToLeft;
    
    protected override void Start()
    {
        base.Start();
        
        //Los necesito para que hacer que no se salga de la pantalla
        _screenSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _sprite = GetComponent<SpriteRenderer>();

        
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        InitializeCommands();
    }

    private void Update()
    {
        Move();
        ChangeDirection();
        
        attackCooldownTimer += Time.deltaTime;
        if(attackCooldownTimer >= Weapon[0].FireRate) Attack();
    }

    private void OnBecameInvisible()
    {
        transform.rotation = new Quaternion(0,0,0,0);
        _isMovingToLeft = false;
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
        if(_isMovingToLeft)
            EntityCommandEventQueue.AddCommandToQueue(CmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
        if(!_isMovingToLeft)
            EntityCommandEventQueue.AddCommandToQueue(CmdMoveRight, CommandEventQueue.UpdateFilter.Fixed);
    }
    
    private void ChangeDirection()
    {
        if (transform.position.x >= _screenSpace.x)
        {
            _isMovingToLeft = true;
            transform.position = new Vector3(_screenSpace.x - (_sprite.sprite.rect.width / _sprite.sprite.pixelsPerUnit * transform.localScale.x) ,transform.position.y, transform.position.z);
            transform.Rotate(0, 0,-180);
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
