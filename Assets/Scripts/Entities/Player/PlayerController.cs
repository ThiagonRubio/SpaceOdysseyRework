using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CommandEventQueue))]
public class PlayerController : Actor, IMoveable, IAttacker
{
    public float Speed => ActorStats.MovementSpeed;

    //----COMMANDS----
    public CommandEventQueue EntityCommandEventQueue { get { return entityCommandEventQueue; } }
    public CmdMove CmdMoveLeft { get { return cmdMoveLeft; } }
    public CmdMove CmdMoveRight { get { return cmdMoveRight; } }
    public CmdMove CmdMoveUp { get { return cmdMoveUp; } }
    public CmdMove CmdMoveDown { get { return cmdMoveDown; } }
    
    //IAttacker
    public IWeapon[] Weapon => _weapons;
    public float AttackCooldownTimer => attackCooldownTimer;


    //----PRIVATE VARS----
    private PlayerInputActions playerInputActions;

    private CommandEventQueue entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;

    //---IATTACKER IMPL----
    private IWeapon[] _weapons;
    private float attackCooldownTimer = 0;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    protected override void Awake()
    {
        base.Awake();
        playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        InitializeCommands();
        _weapons = GetComponentsInChildren<IWeapon>(true);
    }
    private void Update()
    {
        attackCooldownTimer += Time.deltaTime;

        ListenForMoveInput();
        ListenForShootInput();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    //----INIT------
    public void InitializeCommands()
    {
        entityCommandEventQueue = GetComponent<CommandEventQueue>();

        cmdMoveRight = new CmdMove(entityRb, Vector2.right, ActorStats.MovementSpeed);
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, ActorStats.MovementSpeed);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, ActorStats.MovementSpeed);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, ActorStats.MovementSpeed);
    }

    //-----INPUTS--------
    private void ListenForMoveInput()
    {
        if (playerInputActions.Normal.Move.IsPressed())
            Move();
    }
    private void ListenForShootInput()
    {
        /* El array de weapons es literal sólo para el jefe, que de todas formas tiene 5 armas pero son todas la misma
         Voy a dejar esto así, como asumiendo que el firerate de todas las armas es el mismo, pero está feo*/
        
        if (playerInputActions.Normal.Shoot.IsPressed() && attackCooldownTimer >= Weapon[0].FireRate)
        {
           Attack();
        }
    }

    //---ACTION INTERFACES IMPL---------
    //----COMMAND EXECUTION-----
    public void Move()
    {
        Vector2 directionValue = playerInputActions.Normal.Move.ReadValue<Vector2>();

        if (directionValue != Vector2.zero)
        {
            if (directionValue.x < 0)
            {
                entityCommandEventQueue.AddCommandToQueue(cmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.x > 0)
            {
                entityCommandEventQueue.AddCommandToQueue(cmdMoveRight, CommandEventQueue.UpdateFilter.Fixed);
            }

            if (directionValue.y > 0)
            {
                entityCommandEventQueue.AddCommandToQueue(cmdMoveUp, CommandEventQueue.UpdateFilter.Fixed);
            }
            if (directionValue.y < 0)
            {
                entityCommandEventQueue.AddCommandToQueue(cmdMoveDown, CommandEventQueue.UpdateFilter.Fixed);
            }
        }
    }


    public void Attack()
    {
        attackCooldownTimer = 0;
        for (int i = 0; i < Weapon.Length; i++)
        {
            Weapon[i].UseWeapon();
        }
    }
}
