using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance => instance;
    
    private static SoundManager instance;
    
    [SerializeField] private AudioClip[] audios;
    private Dictionary<string, AudioClip> _audiosDictionary;
    private AudioSource controlAudio;

    
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

    private void Start()
    {
        controlAudio = GetComponent<AudioSource>();
        _audiosDictionary = new Dictionary<string, AudioClip>();
        
        for (int i = 0; i < audios.Length; i++)
        {
            _audiosDictionary.Add(Path.GetFileNameWithoutExtension(audios[i].name), audios[i]);
        }
    }

    public void ReproduceSound(string audioName, float volume)
    {
        controlAudio.PlayOneShot(_audiosDictionary[audioName], volume);
    }

    public void ButtonClicked()
    {
        ReproduceSound(AudioConstants.ButtonClicked,1);
    }
    public void ButtonSelected()
    {
        ReproduceSound(AudioConstants.ButtonSelected,1);
    }
}
