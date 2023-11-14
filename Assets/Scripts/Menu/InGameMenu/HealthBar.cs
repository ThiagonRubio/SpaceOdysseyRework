using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public GridLayoutGroup healthBarParent;
    public PlayerDamageableComponent PlayerDamageable;

    private List<GameObject> healthBars = new List<GameObject>();

    private void Start()
    {
        InitializeHealthBars();
    }

    private void Update()
    {
        UpdateHealthBars();
    }

    void InitializeHealthBars()
    {
        for (int i = 0; i < PlayerDamageable.MaxHealth; i++)
        {
            GameObject healthBarInstance = Instantiate(healthBarPrefab, healthBarParent.transform);
            healthBars.Add(healthBarInstance);
        }
    }

    void UpdateHealthBars()
    {
        for (int i = 0;i < healthBars.Count ;i++)
        {
            healthBars[i].SetActive(i < PlayerDamageable.ActualHealth);
        }
    }

}
