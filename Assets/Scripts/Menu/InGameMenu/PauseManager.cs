using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool IsPaused => _isPaused;
    
    [SerializeField] private Canvas pauseCanvas;
    private bool _isPaused = false;
    [SerializeField] private AudioHighPassFilter bgmHighPassFilter;
    

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.gameObject.SetActive(true);
        bgmHighPassFilter.enabled = true;
        _isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
        bgmHighPassFilter.enabled = false;
        _isPaused = false;
    }

}
