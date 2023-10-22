using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CommandEventQueue))]
public class PlayerController : Actor, IMoveable
{
    public float Speed => stats.MovementSpeed;

    //----COMMANDS----
    public CommandEventQueue EntityCommandEventQueue { get { return entityCommandEventQueue; } }
    public CmdMove CmdMoveLeft { get { return cmdMoveLeft; } }
    public CmdMove CmdMoveRight { get { return cmdMoveRight; } }
    public CmdMove CmdMoveUp { get { return cmdMoveUp; } }
    public CmdMove CmdMoveDown { get { return cmdMoveDown; } }

    //----PRIVATE VARS----
    private PlayerInputActions playerInputActions;

    private CommandEventQueue entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;

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
    }
    private void Update()
    {
        ListenForMoveInput();
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

        //Aca va un entityStats.MoveSpeed despues
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, stats.MovementSpeed);
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, stats.MovementSpeed);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, stats.MovementSpeed);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, stats.MovementSpeed);
    }

    //-----INPUTS--------
    private void ListenForMoveInput()
    {
        if (playerInputActions.Normal.Move.IsPressed())
            Move();
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
}
