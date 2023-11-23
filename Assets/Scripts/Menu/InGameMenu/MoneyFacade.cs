using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFacade : MonoBehaviour
{
    [SerializeField] private MoneyUI moneyUI;

    public void UpdateTotalMoney(float totalMoney)
    {
        moneyUI.UpdateTotalMoney(totalMoney);
    }

    public void UpdateActualMoney(float actualMoney, float score, float moneyScoreMultiplier)
    {
        moneyUI.UpdateActualMoney(actualMoney, score, moneyScoreMultiplier);
    }
}
