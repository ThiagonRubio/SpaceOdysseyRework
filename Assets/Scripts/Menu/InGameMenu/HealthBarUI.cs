using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    private GridLayoutGroup _healthBarParent;
    private PlayerDamageableComponent _playerDamageable;
    private List<GameObject> _healthBars = new List<GameObject>();

    private void Start()
    {
        _healthBarParent = GetComponent<GridLayoutGroup>();
        _playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamageableComponent>();
    }

    public void InitializeHealthBars()
    {
        for (int i = 0; i < _playerDamageable.MaxHealth; i++)
        {
            GameObject healthBarInstance = Instantiate(healthBarPrefab, _healthBarParent.transform);
            _healthBars.Add(healthBarInstance);
        }
    }

    public void UpdateHealthBars()
    {
        for (int i = 0; i < _healthBars.Count; i++)
        {
            _healthBars[i].SetActive(i < _playerDamageable.ActualHealth);
        }
    }
}
