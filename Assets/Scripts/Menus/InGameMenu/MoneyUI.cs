using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalMoneyText;
    [SerializeField] private TextMeshProUGUI moneyCalculatorText;

    public void UpdateTotalMoney(float totalMoney)
    {
        totalMoneyText.text = ($"YOU HAVE {totalMoney} COINS" );
    }    

    public void UpdateActualMoney(float score, float moneyScoreMultiplier, float actualMoney)
    {
        moneyCalculatorText.text = ($"{score} SCORE x {moneyScoreMultiplier} = {actualMoney} COINS");
    }


}
