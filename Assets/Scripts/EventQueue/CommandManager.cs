using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Queue<ICommand> _events = new Queue<ICommand>();
    private List<IReversibleCommand> _doneEvents = new List<IReversibleCommand>();
    private const int MAX_UNDOS = 50; //Número a modificar según cuanto sea realmente

    public void AddEvents(ICommand command) => _events.Enqueue(command);

    public void UndoCommands()
    {
        for (int i = _doneEvents.Count - 1; i >= 0; i--)
        {
            _doneEvents[i].Reverse();
            _doneEvents.RemoveAt(i);
        }
    }

    public void EraseDoneCommands() //Por si quiero borrar la lista sin ejecutarlos
    {
        for (int i = _doneEvents.Count - 1; i >= 0; i--)
        {
            _doneEvents.RemoveAt(i);
        }
    }

    private void Update()
    {
        while (_events.Count > 0 && Time.timeScale > 0.1f)
        {
            var command = _events.Dequeue();
            if (command is IReversibleCommand reversibleCommand) _doneEvents.Add(reversibleCommand);
            if (_doneEvents.Count > MAX_UNDOS) _doneEvents.RemoveAt(0);
            command.Execute();
        }
    }
}

