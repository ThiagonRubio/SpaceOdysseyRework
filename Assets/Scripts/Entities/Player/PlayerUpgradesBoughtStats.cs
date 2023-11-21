using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradesBoughtStats : MonoBehaviour
{
    public int HpUpgradesBought => hpUpgradesBought;
    public int AttackUpgradesBought => attackUpgradesBought;
    public int SpeedUpgradesBought => speedUpgradesBought;
    public int SkillDurationUpgradesBought => skillDurationUpgradesBought;
    public int SkillCooldownUpgradesBought => skillCooldownUpgradesBought;
    public int BulletFireRateUpgradesBought => bulletFireRateUpgradesBought;
    public int DoubleTapUpgradesBought => doubleTapUpgradesBought;
    public int TripleShotUpgradesBought => tripleShotUpgradesBought;
    public int CoinMultiplierUpgradesBought => coinMultiplierUpgradesBought;
    
    [SerializeField, HideInInspector] private int hpUpgradesBought;
    [SerializeField, HideInInspector] private int attackUpgradesBought;
    [SerializeField, HideInInspector] private int speedUpgradesBought;
    [SerializeField, HideInInspector] private int skillDurationUpgradesBought;
    [SerializeField, HideInInspector] private int skillCooldownUpgradesBought;
    [SerializeField, HideInInspector] private int bulletFireRateUpgradesBought;
    [SerializeField, HideInInspector] private int doubleTapUpgradesBought;
    [SerializeField, HideInInspector] private int tripleShotUpgradesBought;
    [SerializeField, HideInInspector] private int coinMultiplierUpgradesBought;
    
    public void InitDefaultStats()
    {
        hpUpgradesBought = 0;
        attackUpgradesBought = 0;
        speedUpgradesBought = 0;
        skillDurationUpgradesBought = 0;
        skillCooldownUpgradesBought = 0;
        bulletFireRateUpgradesBought = 0;
        doubleTapUpgradesBought = 0;
        tripleShotUpgradesBought = 0;
        coinMultiplierUpgradesBought = 0;
    }
    
    public void UpgradeBought(string statUpgraded)
    {
        switch (statUpgraded)
        {
            case UpgradeableStatsConstants.HealthPoints:
                hpUpgradesBought++;
                break;
            case UpgradeableStatsConstants.Attack:
                attackUpgradesBought++;
                break;
            case UpgradeableStatsConstants.Speed:
                speedUpgradesBought++;
                break;
            case UpgradeableStatsConstants.SkillDuration:
                skillDurationUpgradesBought++;
                break;
            case UpgradeableStatsConstants.SkillCooldown:
                skillCooldownUpgradesBought++;
                break;
            case UpgradeableStatsConstants.FireRate:
                bulletFireRateUpgradesBought++;
                break;
            case UpgradeableStatsConstants.DoubleTap:
                doubleTapUpgradesBought++;
                break;
            case UpgradeableStatsConstants.TripleShot:
                tripleShotUpgradesBought++;
                break;
            case UpgradeableStatsConstants.CoinMultiplier:
                coinMultiplierUpgradesBought++;
                break;
        }
    }
}
