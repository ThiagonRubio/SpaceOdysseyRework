using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEventQueue : MonoBehaviour
{
    public bool IsCommandQueueFrozen { get { return isCommandQueueFrozen; } }

    public enum UpdateFilter
    {
        Normal,
        Fixed
    }

    private Queue<ICommand> eventQueue = new Queue<ICommand>();
    private Queue<ICommand> fixedUpdateEventQueue = new Queue<ICommand>();
    private bool isCommandQueueFrozen = false;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    private void Update()
    {
        while (eventQueue.Count > 0)
        {
            var command = eventQueue.Dequeue();

            if (isCommandQueueFrozen)
            {
                continue;
            }
            else command.Do();
        }
    }

    private void FixedUpdate()
    {
        while (fixedUpdateEventQueue.Count > 0)
        {
            var command = fixedUpdateEventQueue.Dequeue();

            if (isCommandQueueFrozen)
            {
                continue;
            }
            else command.Do();
        }
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void AddCommandToQueue(ICommand command, UpdateFilter updateFilter)
    {
        if (updateFilter == UpdateFilter.Normal)
            eventQueue.Enqueue(command);
        else if (updateFilter == UpdateFilter.Fixed)
            fixedUpdateEventQueue.Enqueue(command);
    }
}