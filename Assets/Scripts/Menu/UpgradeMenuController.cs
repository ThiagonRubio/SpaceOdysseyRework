using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuController : MonoBehaviour
{
    [SerializeField] private int[] hpPrices;
    [SerializeField] private int[] attackPrices;
    [SerializeField] private int[] speedPrices;
    [SerializeField] private int[] skillDurationPrices;
    [SerializeField] private int[] skillCooldownPrices;
    [SerializeField] private int[] bulletFireRatePrices;
    [SerializeField] private int[] doubleTapPrices;
    [SerializeField] private int[] tripleShotPrices;
    [SerializeField] private int[] coinMultiplierPrices;

    private PlayerSavedStats _stats;
    
    void Start()
    {
        SaveSystem.LoadFromJson(_stats);
    }

    public void HpUpgradeButton()
    {
        if (_stats.UpgradesBoughtData.HpUpgradesBought < hpPrices.Length - 1)
        {
            if (_stats.MoneyStored >= hpPrices[_stats.UpgradesBoughtData.HpUpgradesBought + 1])
            {
                _stats.SaveMoneyData(-hpPrices[_stats.UpgradesBoughtData.HpUpgradesBought + 1]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.HealthPoints);
                //Cómo aumento la variable de las stats T-T
                //Guardo el stats con _stats.SaveData(_stats);
            }
        }
    }
    
}
