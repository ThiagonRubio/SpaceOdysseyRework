using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VolumesController))]
public class VolumeChangedReceiver : MonoBehaviour, IListener
{
    private AudioSource _audioSource;
    private VolumesController _volumeController; 
    [SerializeField] private string soundType;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _volumeController = GetComponent<VolumesController>();
        EventManager.Instance.AddListener(EventConstants.VolumeChanged, this);
        SetVolume();
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventConstants.VolumeChanged, this);
    }

    public void SetVolume()
    {
        _audioSource.volume = _volumeController.LoadVolume(soundType);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        SetVolume();
    }
}
