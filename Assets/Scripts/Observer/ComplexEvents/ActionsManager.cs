using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class ActionsManager
{
    private static Dictionary<string, Action<Transform>> actions = new Dictionary<string, Action<Transform>>();

    public static void InvokeAction(string eventKey, Transform transformReceived)
    {
        if (!actions.ContainsKey(eventKey))
        {
            Debug.LogWarning($"Tried to invoke {eventKey}, but no action was found");
            return;
        }

        actions[eventKey]?.Invoke(transformReceived);
    }

    public static void RegisterAction(string eventKey)
    {
        if (actions.ContainsKey(eventKey))
        {
            Debug.LogWarning($"Tried to register {eventKey}, but it is already registered");
            return;
        }

        actions.Add(eventKey, new Action<Transform>((Transform transform) => { }));
    }

    public static void SubscribeToAction(string eventKey, Action<Transform> action)
    {
        if (!actions.ContainsKey(eventKey))
        {
            RegisterAction(eventKey);
        }

        actions[eventKey] += action;
    }

    public static void UnsubscribeToAction(string eventKey, Action<Transform> action)
    {
        if (!actions.ContainsKey(eventKey))
        {
            Debug.LogWarning($"Tried to unsubscribe to {eventKey}, but no action was found");
            return;
        }

        actions[eventKey] -= action;
    }

    public static void DeleteAction(string eventKey)
    {
        if (!actions.ContainsKey(eventKey))
        {
            Debug.LogWarning($"Tried to delete {eventKey}, but no action was found");
            return;
        }

        actions[eventKey] = null;
        actions.Remove(eventKey);
    }

    public static void DeleteAllActions()
    {
        foreach (var item in actions)
        {
            DeleteAction(item.Key);
        }
    }
}
