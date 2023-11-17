using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthBarFacade _healthBarFacade;

    private void Start()
    {
        _healthBarFacade.InitializeHealthBars();
    }

    private void Update()
    {
        _healthBarFacade.UpdateHealthBars();
    }

}
