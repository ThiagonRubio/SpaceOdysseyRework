using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSavedStats))]
public class UpgradeMenuController : MonoBehaviour
{
    public int[] HpPrices => hpPrices;
    public int[] AttackPrices => attackPrices;
    public int[] SpeedPrices => speedPrices;
    public int[] SkillDurationPrices => skillDurationPrices;
    public int[] SkillCooldownPrices => skillCooldownPrices;
    public int[] BulletFireRatePrices => bulletFireRatePrices;
    public int[] DoubleTapPrices => doubleTapPrices;
    public int[] TripleShotPrices => tripleShotPrices;
    public int[] CoinMultiplierPrices => coinMultiplierPrices; 

    public float[] HpValues => hpValues;
    public float[] AttackValues => attackValues;
    public float[] SpeedValues => speedValues;
    public float[] SkillDurationValues => skillDurationValues;
    public float[] SkillCooldownValues => skillCooldownValues;
    public float[] BulletFireRateValues => bulletFireRateValues;
    public float[] DoubleTapValues => doubleTapValues;
    public float[] TripleShotValues => tripleShotValues;
    public float[] CoinMultiplierValues => coinMultiplierValues;

    public PlayerSavedStats CurrentLoadedSessionData => _stats;

    
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
    
    private void Awake()
    {
        _stats = GetComponent<PlayerSavedStats>();
        SaveSystem.LoadFromJson(_stats);
    }

    public void HpUpgradeButton()
    {
        if (_stats.HpUpgradesBought < hpPrices.Length)
        {
            int index = _stats.HpUpgradesBought;
            if (_stats.MoneyStored >= hpPrices[index])
            {
                _stats.SaveMoneyData(-hpPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.HealthPoints, hpPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.HealthPoints, hpValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void AttackUpgradeButton()
    {
        if (_stats.AttackUpgradesBought < attackPrices.Length)
        {
            int index = _stats.AttackUpgradesBought;
            if (_stats.MoneyStored >= attackPrices[index])
            {
                _stats.SaveMoneyData(-attackPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.Attack, attackPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Attack, attackValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SpeedUpgradeButton()
    {
        if (_stats.SpeedUpgradesBought < speedPrices.Length)
        {
            int index = _stats.SpeedUpgradesBought;
            if (_stats.MoneyStored >= speedPrices[index])
            {
                _stats.SaveMoneyData(-speedPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.Speed, speedPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Speed, speedValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SkillDurationUpgradeButton()
    {
        if (_stats.SkillDurationUpgradesBought < skillDurationPrices.Length)
        {
            int index = _stats.SkillDurationUpgradesBought;
            if (_stats.MoneyStored >= skillDurationPrices[index])
            {
                _stats.SaveMoneyData(-skillDurationPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.SkillDuration, skillDurationPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillDuration, skillDurationValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SkillCooldownUpgradeButton()
    {
        if (_stats.SkillCooldownUpgradesBought < skillCooldownPrices.Length)
        {
            int index = _stats.SkillCooldownUpgradesBought;
            if (_stats.MoneyStored >= skillCooldownPrices[index])
            {
                _stats.SaveMoneyData(-skillCooldownPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.SkillCooldown, skillCooldownPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillCooldown, skillCooldownValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void BulletFireRateUpgradeButton()
    {
        if (_stats.BulletFireRateUpgradesBought < bulletFireRatePrices.Length)
        {
            int index = _stats.BulletFireRateUpgradesBought;
            if (_stats.MoneyStored >= bulletFireRatePrices[index])
            {
                _stats.SaveMoneyData(-bulletFireRatePrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.FireRate, bulletFireRatePrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.FireRate, bulletFireRateValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void DoubleTapUpgradeButton()
    {
        if (_stats.DoubleTapUpgradesBought < doubleTapPrices.Length)
        {
            int index = _stats.DoubleTapUpgradesBought;
            if (_stats.MoneyStored >= doubleTapPrices[index])
            {
                _stats.SaveMoneyData(-doubleTapPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.DoubleTap, doubleTapPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.DoubleTap, doubleTapValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void TripleShotUpgradeButton()
    {
        if (_stats.TripleShotUpgradesBought < tripleShotPrices.Length)
        {
            int index = _stats.TripleShotUpgradesBought;
            if (_stats.MoneyStored >= tripleShotPrices[index])
            {
                _stats.SaveMoneyData(-tripleShotPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.TripleShot, tripleShotPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.TripleShot, tripleShotValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void CoinMultiplierUpgradeButton()
    {
        if (_stats.CoinMultiplierUpgradesBought < coinMultiplierPrices.Length)
        {
            int index = _stats.CoinMultiplierUpgradesBought;
            if (_stats.MoneyStored >= coinMultiplierPrices[index])
            {
                _stats.SaveMoneyData(-coinMultiplierPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.CoinMultiplier, coinMultiplierPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.CoinMultiplier, coinMultiplierValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
}
