using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(CommandEventQueue))]
public class PlayerController : Actor, IMoveable, IAttacker, IListener
{
    public float Speed => ActorStats.MovementSpeed;

    //----COMMANDS----
    public CommandEventQueue EntityCommandEventQueue { get { return _entityCommandEventQueue; } }
    public CmdMove CmdMoveLeft { get { return _cmdMoveLeft; } }
    public CmdMove CmdMoveRight { get { return _cmdMoveRight; } }
    public CmdMove CmdMoveUp { get { return _cmdMoveUp; } }
    public CmdMove CmdMoveDown { get { return _cmdMoveDown; } }
    public CmdAttack CmdAttack { get { return _cmdAttack; } }

    //IAttacker
    public IWeapon[] Weapon => _weapons;
    public float AttackCooldownTimer => attackCooldownTimer;

    //----PRIVATE VARS----
    private PlayerInputActions _playerInputActions;

    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;

    private CmdAttack _cmdAttack;

    //---IATTACKER IMPL----
    private IWeapon[] _weapons;
    private float attackCooldownTimer = 0;

    private float skillCooldownTimer = 0;
    private float skillDurationTimer = 0;
    public bool isSkillActive = false;
    public bool isSkillInCooldown = false;

    private bool gameEnded;
    
    
    private PlayerSavedStats playerUpgradeableStats;
    
    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    protected override void Awake()
    {
        base.Awake();
        _playerInputActions = new PlayerInputActions();
        playerUpgradeableStats = GetComponent<PlayerSavedStats>();
        ResetSkillTimers(true);
    }

    private void Start()
    {
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        InitializeCommands();
    }
    private void Update()
    {
        if (!gameEnded)
        {
            attackCooldownTimer += Time.deltaTime;

            ListenForMoveInput();
            ListenForShootInput();

            if (isSkillActive == false)
            {
                skillCooldownTimer -= Time.deltaTime;

                if (skillCooldownTimer <= 0)
                    ListenForSkillActivateInput();

            }
            else
            {
                ListenForSkillDeactivation();
            }
        }

        ClampMoveToScreen();
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
        EventManager.Instance.AddListener(EventConstants.Won, this);
    }
    private void OnDisable()
    {
        _playerInputActions.Disable();
        EventManager.Instance.RemoveListener(EventConstants.Won, this);
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    //----INIT------
    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();

        _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
        _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
        _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);

        _cmdAttack = new CmdAttack(Weapon);
    }
    public void SetWeaponToUse(IWeapon[] weaponsToUse)
    {
        _weapons = weaponsToUse;
    }

    //-----INPUTS--------
    private void ListenForMoveInput()
    {
        entityAnim.SetBool(AnimationConstants.PlayerMoving, true);
        if (_playerInputActions.Normal.Move.IsPressed())
            Move();
        else
            entityAnim.SetBool(AnimationConstants.PlayerMoving, false);
    }
    private void ListenForShootInput()
    {
        /* El array de weapons es literal sólo para el jefe, que de todas formas tiene 5 armas pero son todas la misma
         Voy a dejar esto así, como asumiendo que el firerate de todas las armas es el mismo, pero está feo*/
        
        if (_playerInputActions.Normal.Shoot.IsPressed() && attackCooldownTimer >= Weapon[0].FireRate)
        {
           Attack();
        }
    }

    private void ListenForSkillActivateInput()
    {
        isSkillInCooldown = false;
        if (_playerInputActions.Normal.Skill.WasPressedThisFrame())
        {
            ActivateSkill(true);
        }
    }
    private void ListenForSkillDeactivation()
    {
        skillDurationTimer -= Time.deltaTime;

        if (skillDurationTimer <= 0)
        {
            ActivateSkill(false);
            isSkillInCooldown = true;
            entityAnim.SetTrigger(AnimationConstants.PlayerSkillDeactivation);
            SoundManager.Instance.ReproduceSound(AudioConstants.SkillDeactivate, 1);
            ResetSkillTimers(false);
        }
    }

    //---ACTION INTERFACES IMPL---------
    //----COMMAND EXECUTION-----
    public void Move()
    {
        Vector2 directionValue = _playerInputActions.Normal.Move.ReadValue<Vector2>();

        if (directionValue != Vector2.zero)
        {
            if (directionValue.x < 0)
            {
                _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                EntityCommandEventQueue.AddCommandToQueue(_cmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.x > 0)
            {
                _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                EntityCommandEventQueue.AddCommandToQueue(_cmdMoveRight,CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.y > 0)
            {
                _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                EntityCommandEventQueue.AddCommandToQueue(_cmdMoveUp, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.y < 0)
            {
                _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                EntityCommandEventQueue.AddCommandToQueue(_cmdMoveDown, CommandEventQueue.UpdateFilter.Fixed);
            }
        }
    }

    //----ATK COMMAND-----
    public void Attack()
    {
        attackCooldownTimer = 0;
        _entityCommandEventQueue.AddCommandToQueue(CmdAttack, CommandEventQueue.UpdateFilter.Normal);
    }
    

    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.Won)
        {
            gameEnded = true;
        } 
    }

    private void ActivateSkill(bool isActivated)
    {
        isSkillActive = isActivated;
        if (isActivated)
        {
            entityAnim.SetTrigger(AnimationConstants.PlayerSkillActivation);
            SoundManager.Instance.ReproduceSound(AudioConstants.SkillActivate, 1);
        }
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), isActivated);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyProjectile"), LayerMask.NameToLayer("Player"), isActivated);
    }
    private void ResetSkillTimers(bool isGameStarting)
    {
        skillCooldownTimer = playerUpgradeableStats.SkillCooldown;
        skillDurationTimer = playerUpgradeableStats.SkillDuration;

        //Para que la skill se pueda usar inmediatamente al iniciar
        if (isGameStarting)
            skillCooldownTimer = 0;
    }
    private void ClampMoveToScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        pos.x = Mathf.Clamp(pos.x, 0.13f, 0.99f);
        pos.y = Mathf.Clamp(pos.y, 0.08f, 0.92f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
