using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private GridLayoutGroup _healthBarParent;
    [SerializeField] private PlayerDamageableComponent _playerDamageable;
    private List<GameObject> _healthBars = new List<GameObject>();

    [SerializeField] private FadeEffect redFrameFadeEffectScript;
    
    public void InitializeHealthBars()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject healthBarInstance = Instantiate(healthBarPrefab, _healthBarParent.transform);
            _healthBars.Add(healthBarInstance);
        }
        UpdateHealthBars();
    }

    public void UpdateHealthBars()
    {
        for (int i = 0; i < _healthBars.Count; i++)
        {
            _healthBars[i].SetActive(i < _playerDamageable.ActualHealth);
        }

        if (_playerDamageable.ActualHealth > 1)
        {
            redFrameFadeEffectScript.AutomaticallyHideUI();
        }
        else
        {
            redFrameFadeEffectScript.ShowUI();
        }
    }
}
