using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarUI : MonoBehaviour /* , IListener */
{
    private Slider _progressSlider;
    public SpawnerControllerStats Stats => stats;
    [SerializeField] private SpawnerControllerStats stats;

    private float _barPartition;
    private float _progress = 0;

    private void Start()
    {
        _progressSlider = GetComponent<Slider>();
    }

    public void ProgressBarStart()
    {
        _barPartition = 1f / Stats.EnemiesBetweenBosses;

        if (_progressSlider != null)
        {
            _progressSlider.value = _progress;
        }
    }

    public void EnemyDied()
    {
        _progress += _barPartition;
        _progress = Mathf.Clamp01(_progress);

        if (_progressSlider != null)
        {
            _progressSlider.value = _progress;
        }
    }

    public void BossDied()
    {
        _progress = 0;
        _progressSlider.value = _progress;
    }
}
