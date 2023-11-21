using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBarFacade : MonoBehaviour, IListener
{

    [SerializeField] private ProgressBarUI progressBarFacade;
    private void Start()
    {
        EventManager.Instance.AddListener(EventConstants.EnemyDeath, this);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
        progressBarFacade.ProgressBarStart();
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventConstants.EnemyDeath, this);
        EventManager.Instance.RemoveListener(EventConstants.BossDeath, this);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.EnemyDeath)
        {
            progressBarFacade.EnemyDied();
        }

        if (invokedEvent == EventConstants.BossDeath)
        {
            progressBarFacade.BossDied();
        }
    }
}
