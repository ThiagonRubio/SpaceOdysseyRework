using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFacade : MonoBehaviour
{
    [SerializeField] private HealthBarUI _healthBarFacade;

    private void Start()
    {
        _healthBarFacade.InitializeHealthBars();
    }

    public void UpdateHealth()
    {
        _healthBarFacade.UpdateHealthBars();
    }

}
