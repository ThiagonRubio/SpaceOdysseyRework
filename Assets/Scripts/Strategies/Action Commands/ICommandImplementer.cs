using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandImplementer
{
    CommandEventQueue EntityCommandEventQueue { get; }
    void InitializeCommands();
}
