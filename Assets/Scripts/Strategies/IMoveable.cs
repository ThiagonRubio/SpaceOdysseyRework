using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable : ICommandImplementer
{
    float Speed { get; }
    CmdMove CmdMoveLeft { get; }
    CmdMove CmdMoveRight { get; }
    CmdMove CmdMoveUp { get; }
    CmdMove CmdMoveDown { get; }
    void Move();
}
