using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CommandEventQueue))]
public class PlayerController : ActorEntity, IMoveable
{
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

    [SerializeField] private float speedEstaVariabaleSeReemplazaDespuesSaludos;

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
        cmdMoveRight = new CmdMove(entityRb, Vector2.right, speedEstaVariabaleSeReemplazaDespuesSaludos);
        cmdMoveLeft = new CmdMove(entityRb, Vector2.left, speedEstaVariabaleSeReemplazaDespuesSaludos);
        cmdMoveUp = new CmdMove(entityRb, Vector2.up, speedEstaVariabaleSeReemplazaDespuesSaludos);
        cmdMoveDown = new CmdMove(entityRb, Vector2.down, speedEstaVariabaleSeReemplazaDespuesSaludos);
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
