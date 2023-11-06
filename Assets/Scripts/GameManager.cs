using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IListener
{
    //[SerializeField] private GameObject inGameCanvas;
    //[SerializeField] private GameObject GameOverCanvas;

    public void Start()
    {
        EventManager.Instance.AddListener(EventConstants.PlayerDeath, this);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
    }

    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.PlayerDeath)
        {
            EventManager.Instance.DispatchSimpleEvent(EventConstants.Lost);
        }
        if (invokedEvent == EventConstants.BossDeath)
        {
            EventManager.Instance.DispatchSimpleEvent(EventConstants.Won);
        }
    }
}
