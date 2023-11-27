using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour, ISelectHandler
{
    [SerializeField] private SoundManager _scenesSoundManager;
    private CanvasGroup _buttonsCanvas;

    private void Start()
    {
        _scenesSoundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _buttonsCanvas = GetComponentInParent<CanvasGroup>();
    }

    public void PlayButtonSound()
    {
        if(_scenesSoundManager != null)
            _scenesSoundManager.ButtonClicked();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(_scenesSoundManager != null && _buttonsCanvas.interactable)
            _scenesSoundManager.ButtonSelected();
    }
}
