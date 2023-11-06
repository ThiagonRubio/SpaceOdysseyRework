using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandEventQueue))]
public class PlayerController : Actor, IMoveable, IAttacker
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

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    protected override void Awake()
    {
        base.Awake();
        _playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        SetWeaponToUse(GetComponentsInChildren<IWeapon>(true));
        InitializeCommands();
    }
    private void Update()
    {
        attackCooldownTimer += Time.deltaTime;

        ListenForMoveInput();
        ListenForShootInput();

        ClampMoveToScreen();
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }
    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    //----INIT------
    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();

        _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.AddForce);
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.AddForce);
        _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.AddForce);
        _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.AddForce);

        _cmdAttack = new CmdAttack(Weapon);
    }
    public void SetWeaponToUse(IWeapon[] weaponsToUse)
    {
        _weapons = weaponsToUse;
    }

    //-----INPUTS--------
    private void ListenForMoveInput()
    {
        if (_playerInputActions.Normal.Move.IsPressed())
            Move();
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

    //---ACTION INTERFACES IMPL---------
    //----COMMAND EXECUTION-----
    public void Move()
    {
        Vector2 directionValue = _playerInputActions.Normal.Move.ReadValue<Vector2>();

        if (directionValue != Vector2.zero)
        {
            if (directionValue.x < 0)
            {
                EntityCommandEventQueue.AddCommandToQueue(CmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.x > 0)
            {
                EntityCommandEventQueue.AddCommandToQueue(CmdMoveRight, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.y > 0)
            {
                EntityCommandEventQueue.AddCommandToQueue(CmdMoveUp, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.y < 0)
            {
                EntityCommandEventQueue.AddCommandToQueue(CmdMoveDown, CommandEventQueue.UpdateFilter.Fixed);
            }
        }
    }

    //----ATK COMMAND-----
    public void Attack()
    {
        attackCooldownTimer = 0;
        _entityCommandEventQueue.AddCommandToQueue(CmdAttack, CommandEventQueue.UpdateFilter.Normal);
    }

    private void ClampMoveToScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 1);
        pos.y = Mathf.Clamp(pos.y, 0, 1);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
