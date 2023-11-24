using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private SoundManager _scenesSoundManager;

    private void Start()
    {
        _scenesSoundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void PlayButtonSound()
    {
        if(_scenesSoundManager != null)
            _scenesSoundManager.ButtonClicked();
    }
}
