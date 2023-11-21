using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFacade : MonoBehaviour
{
    [SerializeField] PauseManager pauseManager;

    private void Start()
    {
        ContinueGame();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(!pauseManager.IsPaused)
            {
                PauseGame();
            }
            else ContinueGame();
        }
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
