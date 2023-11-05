using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Actor, IMoveable, IPoolable
{
    public GameObject GameObject => gameObject;

    public float Speed => ActorStats.MovementSpeed;
    
    public CommandEventQueue EntityCommandEventQueue => _entityCommandEventQueue;
    public CmdMove CmdMoveLeft => _cmdMoveLeft;
    public CmdMove CmdMoveRight => _cmdMoveRight;
    public CmdMove CmdMoveUp => _cmdMoveUp;
    public CmdMove CmdMoveDown => _cmdMoveDown;
    
    private CommandEventQueue _entityCommandEventQueue;
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;
    
    void Start()
    {
        InitializeCommands();
    }

    void Update()
    {
        Move();
    }

    public void InitializeCommands()
    {
        _entityCommandEventQueue = GetComponent<CommandEventQueue>();
        
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate);
        _cmdMoveRight = new CmdMove(entityRb, Vector2.right, Speed, CmdMove.MoveType.Translate);
        _cmdMoveUp = new CmdMove(entityRb, Vector2.up, Speed, CmdMove.MoveType.Translate);
        _cmdMoveDown = new CmdMove(entityRb, Vector2.down, Speed, CmdMove.MoveType.Translate);
    }
    
    public void Move()
    {
        EntityCommandEventQueue.AddCommandToQueue(CmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
    }

    public void OnPoolableObjectDisable()
    {
        gameObject.SetActive(false);
    }
    public IProduct Clone()
    {
        return Instantiate(this);
    }

}
