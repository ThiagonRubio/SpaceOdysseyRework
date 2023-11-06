using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour, IListener
{
    public Slider progressSlider;
    public SpawnerControllerStats Stats => stats;
    [SerializeField] private SpawnerControllerStats stats;

    public float barPartition;
    public float progress = 0;

    public void Start()
    {
        EventManager.Instance.AddListener(EventConstants.EnemyDeath, this);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
        barPartition = 1f / Stats.EnemiesBetweenBosses;

        if (progressSlider != null)
        {
            progressSlider.value = progress;
        }
    }

    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.EnemyDeath)
        {
            progress += barPartition;
            progress = Mathf.Clamp01(progress);

            if (progressSlider != null)
            {
                progressSlider.value = progress;
            }
        }
        
        if(invokedEvent == EventConstants.BossDeath)
        {
            progress = 0;
            progressSlider.value = progress;
        }
    }
}
