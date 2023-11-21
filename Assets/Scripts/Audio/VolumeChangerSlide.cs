using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VolumesController))]
[RequireComponent(typeof(Slider))]
public class VolumeChangerSlide : MonoBehaviour
{
    private VolumesController _volumesController;
    private Slider _slider;
    [SerializeField] private string soundType;
    
    private void Start()
    {
        _volumesController = GetComponent<VolumesController>();
        _slider = GetComponent<Slider>();
        _slider.value = _volumesController.LoadVolume(soundType);
    }

    public void SaveNewVolume()
    {
        _volumesController.SaveVolume(_slider.value, soundType);
        EventManager.Instance.DispatchSimpleEvent(EventConstants.VolumeChanged);
    }
}
