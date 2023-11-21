using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFacade : MonoBehaviour
{
    public PauseManager PauseManager => pauseManager;
    
    [SerializeField] PauseManager pauseManager;

    private void Start()
    {
        ContinueGame();
    }
    public void PauseGame()
    {
        pauseManager.PauseGame();
    }

    public void ContinueGame()
    {
        pauseManager.ContinueGame();
    }

}
