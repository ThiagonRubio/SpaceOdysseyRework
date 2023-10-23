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

    //----IPOOLOWNER----
    public GameObject GameObject => this.gameObject;

    public ObjectPool ObjectPool => objectPool;

    public AbstractFactory<IPoolable> CreatorFactory => projectileFactory;

    //----IATTACKER??----
    public Projectile Projectile => projectile;

    public Transform[] ProjectileSpawnPoints => throw new System.NotImplementedException();
    public float AttackCooldownTimer => attackCooldownTimer;

    public float FireRate => fireRate;

    public float Damage => throw new System.NotImplementedException();


    //----PRIVATE VARS----
    private PlayerInputActions playerInputActions;

    private CommandEventQueue entityCommandEventQueue;
    private CmdMove cmdMoveLeft;
    private CmdMove cmdMoveRight;
    private CmdMove cmdMoveUp;
    private CmdMove cmdMoveDown;

    //---IATTACKER IMPL----
    [SerializeField] private Projectile projectile;
    [SerializeField] private float fireRate = 0;
    private float attackCooldownTimer = 0;

    //---IPOOLOWNER IMPL----
    private ObjectPool objectPool;
    private ProjectileFactory projectileFactory;


    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    protected override void Awake()
    {
        base.Awake();
        playerInputActions = new PlayerInputActions();
        objectPool = GetComponent<ObjectPool>();
        projectileFactory = new ProjectileFactory(this, projectile, 6);
    }

    private void Start()
    {
        InitializeCommands();
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
        //Esta muy raro la forma en que esta implementado IAttacker, no usa comando de ataque y es una mezcla entre 
        //lo que haria un attacker y un IWeapon. Va a traer problemas si hay distinas logicas de disparo mas adelante y no se arregla
        //ni se va a poder usar distintos spawn points sin hacer chanchadas
        if (playerInputActions.Normal.Shoot.IsPressed() && attackCooldownTimer >= FireRate)
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
        IProjectile newProjectile = projectileFactory.CreateObject(this);
        newProjectile.SetOwner(this);
    }
}
