using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumesController : MonoBehaviour
{
    public void SaveVolume(float volume, string soundType)
    {
        PlayerPrefs.SetFloat(soundType, volume);
    }

    public float LoadVolume(string soundType)
    {
        return PlayerPrefs.GetFloat(soundType, 1);
    }
}
