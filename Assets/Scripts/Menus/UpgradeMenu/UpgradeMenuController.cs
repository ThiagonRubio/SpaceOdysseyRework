using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerSavedStats))]
public class UpgradeMenuController : MonoBehaviour
{
    public int[] HpPrices => storeStats.HpPrices;
    public int[] AttackPrices => storeStats.AttackPrices;
    public int[] SpeedPrices => storeStats.SpeedPrices;
    public int[] SkillDurationPrices => storeStats.SkillDurationPrices;
    public int[] SkillCooldownPrices => storeStats.SkillCooldownPrices;
    public int[] BulletFireRatePrices => storeStats.BulletFireRatePrices;
    public int[] DoubleTapPrices => storeStats.DoubleTapPrices;
    public int[] TripleShotPrices => storeStats.TripleShotPrices;
    public int[] CoinMultiplierPrices => storeStats.CoinMultiplierPrices; 

    public float[] HpValues => storeStats.HpValues;
    public float[] AttackValues => storeStats.AttackValues;
    public float[] SpeedValues => storeStats.SpeedValues;
    public float[] SkillDurationValues => storeStats.SkillDurationValues;
    public float[] SkillCooldownValues => storeStats.SkillCooldownValues;
    public float[] BulletFireRateValues => storeStats.BulletFireRateValues;
    public float[] DoubleTapValues => storeStats.DoubleTapValues;
    public float[] TripleShotValues => storeStats.TripleShotValues;
    public float[] CoinMultiplierValues => storeStats.CoinMultiplierValues;

    public PlayerSavedStats CurrentLoadedSessionData => _stats;
    
    private PlayerSavedStats _stats;
    [SerializeField] private StoreStats storeStats;
    private void Awake()
    {
        _stats = GetComponent<PlayerSavedStats>();
        SaveSystem.LoadFromJson(_stats);
    }

    public void HpUpgradeButton()
    {
        if (_stats.HpUpgradesBought < HpPrices.Length - 1)
        {
            int index = _stats.HpUpgradesBought;
            if (_stats.MoneyStored >= HpPrices[index])
            {
                _stats.SaveMoneyData(-HpPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.HealthPoints, HpPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.HealthPoints, HpValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void AttackUpgradeButton()
    {
        if (_stats.AttackUpgradesBought < AttackPrices.Length - 1)
        {
            int index = _stats.AttackUpgradesBought;
            if (_stats.MoneyStored >= AttackPrices[index])
            {
                _stats.SaveMoneyData(-AttackPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.Attack, AttackPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Attack, AttackValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SpeedUpgradeButton()
    {
        if (_stats.SpeedUpgradesBought < SpeedPrices.Length - 1)
        {
            int index = _stats.SpeedUpgradesBought;
            if (_stats.MoneyStored >= SpeedPrices[index])
            {
                _stats.SaveMoneyData(-SpeedPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.Speed, SpeedPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.Speed, SpeedValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SkillDurationUpgradeButton()
    {
        if (_stats.SkillDurationUpgradesBought < SkillDurationPrices.Length - 1)
        {
            int index = _stats.SkillDurationUpgradesBought;
            if (_stats.MoneyStored >= SkillDurationPrices[index])
            {
                _stats.SaveMoneyData(-SkillDurationPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.SkillDuration, SkillDurationPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillDuration, SkillDurationValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void SkillCooldownUpgradeButton()
    {
        if (_stats.SkillCooldownUpgradesBought < SkillCooldownPrices.Length - 1)
        {
            int index = _stats.SkillCooldownUpgradesBought;
            if (_stats.MoneyStored >= SkillCooldownPrices[index])
            {
                _stats.SaveMoneyData(-SkillCooldownPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.SkillCooldown, SkillCooldownPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.SkillCooldown, SkillCooldownValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void BulletFireRateUpgradeButton()
    {
        if (_stats.BulletFireRateUpgradesBought < BulletFireRatePrices.Length - 1)
        {
            int index = _stats.BulletFireRateUpgradesBought;
            if (_stats.MoneyStored >= BulletFireRatePrices[index])
            {
                _stats.SaveMoneyData(-BulletFireRatePrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.FireRate, BulletFireRatePrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.FireRate, BulletFireRateValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void DoubleTapUpgradeButton()
    {
        if (_stats.DoubleTapUpgradesBought < DoubleTapPrices.Length - 1)
        {
            int index = _stats.DoubleTapUpgradesBought;
            if (_stats.MoneyStored >= DoubleTapPrices[index])
            {
                _stats.SaveMoneyData(-DoubleTapPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.DoubleTap, DoubleTapPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.DoubleTap, DoubleTapValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void TripleShotUpgradeButton()
    {
        if (_stats.TripleShotUpgradesBought < TripleShotPrices.Length - 1)
        {
            int index = _stats.TripleShotUpgradesBought;
            if (_stats.MoneyStored >= TripleShotPrices[index])
            {
                _stats.SaveMoneyData(-TripleShotPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.TripleShot, TripleShotPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.TripleShot, TripleShotValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
    public void CoinMultiplierUpgradeButton()
    {
        if (_stats.CoinMultiplierUpgradesBought < CoinMultiplierPrices.Length - 1)
        {
            int index = _stats.CoinMultiplierUpgradesBought;
            if (_stats.MoneyStored >= CoinMultiplierPrices[index])
            {
                _stats.SaveMoneyData(-CoinMultiplierPrices[index]);
                _stats.UpgradeBought(UpgradeableStatsConstants.CoinMultiplier, CoinMultiplierPrices.Length);
                _stats.SaveUpgradedStat(UpgradeableStatsConstants.CoinMultiplier, CoinMultiplierValues[index]);
            }
        }
        SaveSystem.LoadFromJson(_stats);
    }
}
