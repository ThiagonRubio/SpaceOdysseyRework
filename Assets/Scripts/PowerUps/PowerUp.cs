using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : Actor, IPowerUp
{
    public GameObject GameObject => gameObject;

    public float Speed => ActorStats.MovementSpeed;
    
    public CmdMove CmdMoveLeft => _cmdMoveLeft;
    public CmdMove CmdMoveRight => _cmdMoveRight;
    public CmdMove CmdMoveUp => _cmdMoveUp;
    public CmdMove CmdMoveDown => _cmdMoveDown;
    
    private CmdMove _cmdMoveLeft;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;

    private enum PowerUpType
    {
        Nuke,
        Shield,
        DoubleTap,
        TripleShot
    }

    [SerializeField] private PowerUpType type;
    
    void Update()
    {
        Move();
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        SoundManager.Instance.ReproduceSound(AudioConstants.PowerUpPicked, 1);
        Effect();
        Destroy(gameObject); //También podría ser pooleable
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject); //También podría ser pooleable
    }
    
    public void Move()
    {
        _cmdMoveLeft = new CmdMove(entityRb, Vector2.left, Speed, CmdMove.MoveType.Translate, Time.deltaTime);
        CmdMoveLeft.Execute();
    }

    public void Effect()
    {
        switch (type)
        {
            case PowerUpType.Nuke:
                EventManager.Instance.DispatchSimpleEvent(EventConstants.NukeEffect);
                break;
            case PowerUpType.Shield:
                EventManager.Instance.DispatchSimpleEvent(EventConstants.MedicKitEffect);
                break;
            case PowerUpType.DoubleTap:
                EventManager.Instance.DispatchSimpleEvent(EventConstants.DoubleTapEffect);
                break;
            case PowerUpType.TripleShot:
                EventManager.Instance.DispatchSimpleEvent(EventConstants.TripleShotEffect);
                break;
        }
        
    }

    public IProduct Clone()
    {
        return Instantiate(this);
    }
}
