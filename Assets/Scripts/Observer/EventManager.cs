using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EventManager
{
    public static EventManager Instance
    {
        get
        {
            if (_instance == null) 
                _instance = new EventManager();
            return _instance;
        }
    }
    private static EventManager _instance;

    private Dictionary<string,List<IListener>> simpleEvents = new();
    private List<IListener> _listeners;

    public void AddListener(string eventID, IListener p_listener)
    {
        if (simpleEvents.TryGetValue(eventID, out _listeners) && !_listeners.Contains(p_listener))
        {
            _listeners.Add(p_listener);
            Debug.Log($"Yo {p_listener} me subscribo al evento {eventID}");
        }
    }
        
    public void RemoveListener(string eventID, IListener p_listener)
    {
        if (simpleEvents.TryGetValue(eventID, out _listeners) && _listeners.Contains(p_listener))
            _listeners.Remove(p_listener);
    }

    public void RemoveAllListeners()
    {
        foreach (var listener in simpleEvents)
        {
            for(int i = 0; i < listener.Value.Count; i++) RemoveListener(listener.Key, listener.Value[i]);
        }
    }

    public void DispatchSimpleEvent(string eventID)
    {
        if (simpleEvents.TryGetValue(eventID, out var listeners))
        {
            Debug.Log($"Despacho el evento {eventID}");
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventDispatch(eventID);
            }
        }
    }

    public void RegisterEvent(string eventID)
    {
        if(!simpleEvents.ContainsKey(eventID))
        {
            simpleEvents.Add(eventID, new List<IListener>());
            Debug.Log($"registro el evento {eventID}");
        }
    }
}
