using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IListener
{
    public GameObject inGameCanvas;
    public GameObject GameOverCanvas;

    public void Start()
    {
        EventManager.Instance.AddListener(EventConstants.PlayerDeath, this);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
    }

    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.PlayerDeath)
        {
            GameOverCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
        }
    }
}
