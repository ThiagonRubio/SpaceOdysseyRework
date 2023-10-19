using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable : ICommandImplementer
{
    CmdMove CmdMoveLeft { get; }
    CmdMove CmdMoveRight { get; }
    CmdMove CmdMoveUp { get; }
    CmdMove CmdMoveDown { get; }
    void Move();
}
