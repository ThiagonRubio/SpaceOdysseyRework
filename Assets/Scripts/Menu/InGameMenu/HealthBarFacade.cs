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
        ApagarMarcoRojoPordefecto();
    }

    public void UpdateHealth()
    {
        _healthBarFacade.UpdateHealthBars();
    }

    public void ApagarMarcoRojoPordefecto()
    {
        _healthBarFacade.ApagarMarcoRojoPorDefecto();
    }
}
