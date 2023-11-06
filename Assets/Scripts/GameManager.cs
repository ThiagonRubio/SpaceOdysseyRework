using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IListener
{
    public static GameManager Instance => instance;

    public bool GamemodeIsStageMode
    {
        set
        {
            gamemodeIsStageMode = value;
        }
    }
    
    private static GameManager instance;
    
    private bool gamemodeIsStageMode;
    
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

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
        if (invokedEvent == EventConstants.BossDeath && gamemodeIsStageMode)
        {
            EventManager.Instance.DispatchSimpleEvent(EventConstants.Won);
        }
    }
}
