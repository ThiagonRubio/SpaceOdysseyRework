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
    
    [SerializeField] private float[] hpValues;
    [SerializeField] private float[] attackValues;
    [SerializeField] private float[] speedValues;
    [SerializeField] private float[] skillDurationValues;
    [SerializeField] private float[] skillCooldownValues;
    [SerializeField] private float[] bulletFireRateValues;
    [SerializeField] private float[] doubleTapValues;
    [SerializeField] private float[] tripleShotValues;
    [SerializeField] private float[] coinMultiplierValues;

    private PlayerSavedStats _stats;
    
    void Start()
    {
        _stats = GetComponent<PlayerSavedStats>();
        SaveSystem.LoadFromJson(_stats);
    }

    public void HpUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.HpUpgradesBought < hpPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.HpUpgradesBought + 1;
            if (_stats.MoneyStored >= hpPrices[index])
            {
                _stats.SaveMoneyData(-hpPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.HealthPoints);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.HealthPoints, hpValues[index]);
            }
        }
    }
    public void AttackUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.AttackUpgradesBought < attackPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.AttackUpgradesBought + 1;
            if (_stats.MoneyStored >= attackPrices[index])
            {
                _stats.SaveMoneyData(-attackPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.Attack);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Attack, attackValues[index]);
            }
        }
    }
    public void SpeedUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.SpeedUpgradesBought < speedPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.SpeedUpgradesBought + 1;
            if (_stats.MoneyStored >= speedPrices[index])
            {
                _stats.SaveMoneyData(-speedPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.Speed);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Speed, speedValues[index]);
            }
        }
    }
    public void SkillDurationUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.SkillDurationUpgradesBought < skillDurationPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.SkillDurationUpgradesBought + 1;
            if (_stats.MoneyStored >= skillDurationPrices[index])
            {
                _stats.SaveMoneyData(-skillDurationPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.SkillDuration);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillDuration, skillDurationValues[index]);
            }
        }
    }
    public void SkillCooldownUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.SkillCooldownUpgradesBought < skillCooldownPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.SkillCooldownUpgradesBought + 1;
            if (_stats.MoneyStored >= skillCooldownPrices[index])
            {
                _stats.SaveMoneyData(-skillCooldownPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.SkillCooldown);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillCooldown, skillCooldownValues[index]);
            }
        }
    }
    public void BulletFireRateUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.BulletFireRateUpgradesBought < bulletFireRatePrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.BulletFireRateUpgradesBought + 1;
            if (_stats.MoneyStored >= bulletFireRatePrices[index])
            {
                _stats.SaveMoneyData(-bulletFireRatePrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.FireRate);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.FireRate, bulletFireRateValues[index]);
            }
        }
    }
    public void DoubleTapUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.DoubleTapUpgradesBought < doubleTapPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.DoubleTapUpgradesBought + 1;
            if (_stats.MoneyStored >= doubleTapPrices[index])
            {
                _stats.SaveMoneyData(-doubleTapPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.DoubleTap);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.DoubleTap, doubleTapValues[index]);
            }
        }
    }
    public void TripleShotUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.TripleShotUpgradesBought < tripleShotPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.TripleShotUpgradesBought + 1;
            if (_stats.MoneyStored >= tripleShotPrices[index])
            {
                _stats.SaveMoneyData(-tripleShotPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.TripleShot);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.TripleShot, tripleShotValues[index]);
            }
        }
    }
    public void CoinMultiplierUpgradeButton()
    {
        SaveSystem.LoadFromJson(_stats);
        if (_stats.UpgradesBoughtData.CoinMultiplierUpgradesBought < coinMultiplierPrices.Length - 1)
        {
            int index = _stats.UpgradesBoughtData.CoinMultiplierUpgradesBought + 1;
            if (_stats.MoneyStored >= coinMultiplierPrices[index])
            {
                _stats.SaveMoneyData(-coinMultiplierPrices[index]);
                _stats.UpgradesBoughtData.UpgradeBought(UpgradeableStatsConstants.CoinMultiplier);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.CoinMultiplier, coinMultiplierValues[index]);
            }
        }
    }
}
