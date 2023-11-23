using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UpgradeType
{
    HP,
    ATK,
    SPD,
    SkDur,
    SkCool,
    BFR,
    DT,
    TS,
    CM
}

public class UpgradesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI upgradeQuantityText;
    private int[] _prices;
    private int _upgradesBought;
    [SerializeField] private UpgradeType upgradeType;
    
    [SerializeField] private UpgradeMenuController upgradeController;

    private void Start()
    {
        ChangeTexts();
    }

    public void ChangeTexts()
    {
        GetUpgradeStats(upgradeType);
        priceText.text = "$" + _prices[_upgradesBought + 1];
    }
    
    private void GetUpgradeStats(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.HP:
                _prices = upgradeController.HpPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.HpUpgradesBought;
                break;
            case UpgradeType.ATK:
                _prices = upgradeController.AttackPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.AttackUpgradesBought;
                break;
            case UpgradeType.SPD:
                _prices = upgradeController.SpeedPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.SpeedUpgradesBought;
                break;
            case UpgradeType.SkDur:
                _prices = upgradeController.SkillDurationPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.SkillDurationUpgradesBought;
                break;
            case UpgradeType.SkCool:
                _prices = upgradeController.SkillCooldownPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.SkillCooldownUpgradesBought;
                break;
            case UpgradeType.BFR:
                _prices = upgradeController.BulletFireRatePrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.BulletFireRateUpgradesBought;
                break;
            case UpgradeType.DT:
                _prices = upgradeController.DoubleTapPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.DoubleTapUpgradesBought;
                break;
            case UpgradeType.TS:
                _prices = upgradeController.TripleShotPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.TripleShotUpgradesBought;
                break;
            case UpgradeType.CM:
                _prices = upgradeController.CoinMultiplierPrices;
                _upgradesBought = upgradeController.UpgradesBoughtStats.CoinMultiplierUpgradesBought;
                break;
        }
    }
}
