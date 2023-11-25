using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public bool IsPaused => _isPaused;
    
    [SerializeField] private Canvas pauseCanvas;
    private bool _isPaused = false;
    [SerializeField] private AudioHighPassFilter bgmHighPassFilter;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject pauseDefaultSelectedButton;
    [SerializeField] private GameObject winLoseDefaultSelectedButton;
    private CanvasGroup pauseCanvasCanvasGroup;

    private void Start()
    {
        pauseCanvasCanvasGroup = pauseCanvas.GetComponent<CanvasGroup>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.gameObject.SetActive(true);
        if (pauseCanvasCanvasGroup != null)
            pauseCanvasCanvasGroup.interactable = true;
        bgmHighPassFilter.enabled = true;
        eventSystem.SetSelectedGameObject(pauseDefaultSelectedButton);
        _isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
        if (pauseCanvasCanvasGroup != null)
            pauseCanvasCanvasGroup.interactable = false;
        bgmHighPassFilter.enabled = false;
        eventSystem.SetSelectedGameObject(winLoseDefaultSelectedButton);
        _isPaused = false;
    }

}
