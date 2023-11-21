using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;


    private bool _isPaused = false;
    public bool IsPaused => _isPaused;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.gameObject.SetActive(true);
        _isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
        _isPaused = false;
    }

}
