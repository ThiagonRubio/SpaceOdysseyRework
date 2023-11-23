using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpgradesUI : MonoBehaviour
{
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

        if (_upgradesBought == _prices.Length - 1)
        {
            priceText.text = "MAX";
        }
        else priceText.text = "$" + _prices[_upgradesBought];

        upgradeQuantityText.text = _upgradesBought + "/" + (_prices.Length - 1);
    }
    
    private void GetUpgradeStats(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.HP:
                _prices = upgradeController.HpPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.HpUpgradesBought;
                break;
            case UpgradeType.ATK:
                _prices = upgradeController.AttackPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.AttackUpgradesBought;
                break;
            case UpgradeType.SPD:
                _prices = upgradeController.SpeedPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.SpeedUpgradesBought;
                break;
            case UpgradeType.SkDur:
                _prices = upgradeController.SkillDurationPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.SkillDurationUpgradesBought;
                break;
            case UpgradeType.SkCool:
                _prices = upgradeController.SkillCooldownPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.SkillCooldownUpgradesBought;
                break;
            case UpgradeType.BFR:
                _prices = upgradeController.BulletFireRatePrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.BulletFireRateUpgradesBought;
                break;
            case UpgradeType.DT:
                _prices = upgradeController.DoubleTapPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.DoubleTapUpgradesBought;
                break;
            case UpgradeType.TS:
                _prices = upgradeController.TripleShotPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.TripleShotUpgradesBought;
                break;
            case UpgradeType.CM:
                _prices = upgradeController.CoinMultiplierPrices;
                _upgradesBought = upgradeController.CurrentLoadedSessionData.CoinMultiplierUpgradesBought;
                break;
        }
    }
}
