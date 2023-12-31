using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor, IMoveable, IAttacker, IListener
{
    public float Speed => ActorStats.MovementSpeed;

    //----COMMANDS----
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
    private bool _isSkillActive = false;
    
    private bool gameEnded;

    [SerializeField] private SkillFacade skillUIFacade;
    [SerializeField] private PauseFacade pauseUIFacade;
    
    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    protected override void Awake()
    {
        base.Awake();
        _playerInputActions = new PlayerInputActions();
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
            if (!pauseUIFacade.PauseManager.IsPaused)
            {
                attackCooldownTimer += Time.deltaTime;

                ListenForMoveInput();
                ListenForShootInput();

                if (_isSkillActive == false)
                {
                    skillUIFacade.UpdateSkillUI(AnimationConstants.SkillInCooldown);
                    skillCooldownTimer -= Time.deltaTime;

                    if (skillCooldownTimer <= 0)
                    {
                        skillUIFacade.UpdateSkillUI(AnimationConstants.SkillAvailable);
                        ListenForSkillActivateInput();
                    }
                }
                else
                {
                    ListenForSkillDeactivation();
                }
            }
            ListenForPauseInput();
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
        _cmdAttack = new CmdAttack(Weapon);
        //Esta sí se puede generar porque no depende del deltatime como las de movimiento
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
        if (_playerInputActions.Normal.Skill.WasPressedThisFrame())
        {
            skillUIFacade.UpdateSkillUI(AnimationConstants.SkillActive);
            ActivateSkill(true);
        }
    }
    private void ListenForSkillDeactivation()
    {
        skillDurationTimer -= Time.deltaTime;

        if (skillDurationTimer <= 0)
        {
            ActivateSkill(false);
            entityAnim.SetTrigger(AnimationConstants.PlayerSkillDeactivation);
            SoundManager.Instance.ReproduceSound(AudioConstants.SkillDeactivate, 1);
            ResetSkillTimers(false);
        }
    }

    private void ListenForPauseInput()
    {
        if (_playerInputActions.Normal.Pause.WasPressedThisFrame())
        {
            if (!pauseUIFacade.PauseManager.IsPaused)
            {
                pauseUIFacade.PauseGame();
                return;
            }
            if (pauseUIFacade.PauseManager.IsPaused)
            {
                pauseUIFacade.ContinueGame();
                return;
            }
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
                CmdMoveLeft.Execute();
            }
            if (directionValue.x > 0)
            {
                _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                CmdMoveRight.Execute();
            }
            if (directionValue.y > 0)
            {
                _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                CmdMoveUp.Execute();
            }
            if (directionValue.y < 0)
            {
                _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.AddForce, Time.deltaTime);
                CmdMoveDown.Execute();
            }
        }
    }

    //----ATK COMMAND-----
    public void Attack()
    {
        attackCooldownTimer = 0;
        CmdAttack.Execute();
        //_entityCommandEventQueue.AddCommandToQueue(CmdAttack, CommandEventQueue.UpdateFilter.Normal);
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
        _isSkillActive = isActivated;
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
        PlayerSavedStats stats = GetComponent<PlayerSavedStats>(); 

        skillCooldownTimer = stats.SkillCooldown;
        skillDurationTimer = stats.SkillDuration;

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
