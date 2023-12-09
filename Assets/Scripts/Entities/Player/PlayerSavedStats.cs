using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSavedStats : MonoBehaviour
{
    public float SkillDuration => upgradedSkillDuration;
    public float SkillCooldown => upgradedSkillCooldown;
    public float TripleShotDuration => upgradedTripleShotDuration;
    public float DoubleTapDuration => upgradedDoubleTapDuration;
    public float UpgradedCoinMultiplier => upgradedCoinMultiplier;
    public float MoneyStored => moneyStored;
    public int HpUpgradesBought => hpUpgradesBought;
    public int AttackUpgradesBought => attackUpgradesBought;
    public int SpeedUpgradesBought => speedUpgradesBought;
    public int SkillDurationUpgradesBought => skillDurationUpgradesBought;
    public int SkillCooldownUpgradesBought => skillCooldownUpgradesBought;
    public int BulletFireRateUpgradesBought => bulletFireRateUpgradesBought;
    public int DoubleTapUpgradesBought => doubleTapUpgradesBought;
    public int TripleShotUpgradesBought => tripleShotUpgradesBought;
    public int CoinMultiplierUpgradesBought => coinMultiplierUpgradesBought;
    
    //----PRIVATE VARS----

    [SerializeField, HideInInspector] private float upgradedMaxHealth;
    [SerializeField, HideInInspector] private float upgradedAttack;
    [SerializeField, HideInInspector] private float upgradedSpeed;
    [SerializeField, HideInInspector] private float upgradedSkillDuration;
    [SerializeField, HideInInspector] private float upgradedSkillCooldown;
    [SerializeField, HideInInspector] private float upgradedBulletFireRate;
    [SerializeField, HideInInspector] private float upgradedDoubleTapDuration;
    [SerializeField, HideInInspector] private float upgradedTripleShotDuration;
    [SerializeField, HideInInspector] private float upgradedCoinMultiplier;
    [SerializeField] private GameObject upgradedExplosionSprite;
    [SerializeField] private Projectile upgradedPlayerProjectile;
    [SerializeField, HideInInspector] private int hpUpgradesBought;
    [SerializeField, HideInInspector] private int attackUpgradesBought;
    [SerializeField, HideInInspector] private int speedUpgradesBought;
    [SerializeField, HideInInspector] private int skillDurationUpgradesBought;
    [SerializeField, HideInInspector] private int skillCooldownUpgradesBought;
    [SerializeField, HideInInspector] private int bulletFireRateUpgradesBought;
    [SerializeField, HideInInspector] private int doubleTapUpgradesBought;
    [SerializeField, HideInInspector] private int tripleShotUpgradesBought;
    [SerializeField, HideInInspector] private int coinMultiplierUpgradesBought;
    [SerializeField, HideInInspector] private float moneyStored;

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    private void Awake()
    {   
        //Para Forzar a que se sobrescriba todos los valores edita el .txt del json directamente

        if (SaveSystem.GetIfSaveFileExists() == false)
        {
            SaveData(InitDefaultSaveFile());
            Debug.LogWarning("Player Save doesn't exist. Creating new one.");
        }
        else 
        {
            SaveSystem.LoadFromJson(this);
            Debug.Log("Money stored is " + moneyStored);
        }
    }

    public ActorStats GetPlayerStats()
    {
        LoadMiscResources();
        ActorStats playerStats = ActorStats.CreateInstance<ActorStats>();
        playerStats.ConstructStats(upgradedMaxHealth, upgradedSpeed, upgradedExplosionSprite);
        return playerStats;
    }
    public WeaponStats GetPlayerWeaponStats()
    {
        LoadWeaponResources();
        WeaponStats playerDefaultWeapon = WeaponStats.CreateInstance<WeaponStats>();
        playerDefaultWeapon.ConstructWeaponStats(upgradedPlayerProjectile, upgradedBulletFireRate, upgradedAttack, 30);
        return playerDefaultWeapon;
    }
    public void SaveMoneyData(float moneyToAdd)
    {
        moneyStored += moneyToAdd;
        SaveData(this);
    }

    public void SaveUpgradedStat(string upgradedStat, float updatedValue)
    {
        switch (upgradedStat)
        {
            case UpgradeableStatsConstants.HealthPoints:
                upgradedMaxHealth = updatedValue;
                break;
            case UpgradeableStatsConstants.Attack:
                upgradedAttack = updatedValue;
                break;
            case UpgradeableStatsConstants.Speed:
                upgradedSpeed = updatedValue;
                break;
            case UpgradeableStatsConstants.SkillDuration:
                upgradedSkillDuration = updatedValue;
                break;
            case UpgradeableStatsConstants.SkillCooldown:
                upgradedSkillCooldown = updatedValue;
                break;
            case UpgradeableStatsConstants.FireRate:
                upgradedBulletFireRate = updatedValue;
                break;
            case UpgradeableStatsConstants.DoubleTap:
                upgradedDoubleTapDuration = updatedValue;
                break;
            case UpgradeableStatsConstants.TripleShot:
                upgradedTripleShotDuration = updatedValue;
                break;
            case UpgradeableStatsConstants.CoinMultiplier:
                upgradedCoinMultiplier = updatedValue;
                break;
        }
        SaveData(this);
    }
    public void UpgradeBought(string statUpgraded, int maxValue)
    {
        switch (statUpgraded)
        {
            case UpgradeableStatsConstants.HealthPoints:
                if (hpUpgradesBought < maxValue - 1)
                    hpUpgradesBought++;
                break;
            case UpgradeableStatsConstants.Attack:
                if (attackUpgradesBought < maxValue - 1)
                    attackUpgradesBought++;
                break;
            case UpgradeableStatsConstants.Speed:
                if (speedUpgradesBought < maxValue - 1)
                    speedUpgradesBought++;
                break;
            case UpgradeableStatsConstants.SkillDuration:
                if (skillDurationUpgradesBought < maxValue - 1)
                    skillDurationUpgradesBought++;
                break;
            case UpgradeableStatsConstants.SkillCooldown:
                if (skillCooldownUpgradesBought < maxValue - 1)
                    skillCooldownUpgradesBought++;
                break;
            case UpgradeableStatsConstants.FireRate:
                if (bulletFireRateUpgradesBought < maxValue - 1)
                    bulletFireRateUpgradesBought++;
                break;
            case UpgradeableStatsConstants.DoubleTap:
                if (doubleTapUpgradesBought < maxValue - 1)
                    doubleTapUpgradesBought++;
                break;
            case UpgradeableStatsConstants.TripleShot:
                if (tripleShotUpgradesBought < maxValue - 1)
                    tripleShotUpgradesBought++;
                break;
            case UpgradeableStatsConstants.CoinMultiplier:
                if (coinMultiplierUpgradesBought < maxValue - 1)
                    coinMultiplierUpgradesBought++;
                break;
        }
        SaveData(this);
    }

    private void SaveData(PlayerSavedStats sessionData)
    {
        SaveSystem.SaveToJson(sessionData);
    }
    private PlayerSavedStats InitDefaultSaveFile()
    {
        PlayerSavedStats defaultFile = this;

        defaultFile.upgradedMaxHealth = 3;
        defaultFile.upgradedAttack = 1f;
        defaultFile.upgradedSpeed = 350;
        defaultFile.upgradedSkillDuration = 3;
        defaultFile.upgradedSkillCooldown = 10;
        defaultFile.upgradedBulletFireRate = 0.5f;
        defaultFile.upgradedDoubleTapDuration = 4;
        defaultFile.upgradedTripleShotDuration = 4;
        defaultFile.upgradedCoinMultiplier = 0.2f;
        defaultFile.moneyStored = 0;
        
        //Esto hay que evitarlo (CONSIGNA)
        //defaultFile.upgradedExplosionSprite = Resources.Load<GameObject>("Prefabs/Explosion/Explosion");
        //defaultFile.upgradedPlayerProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/PlayerProjectile");
        
        defaultFile.hpUpgradesBought = 0;
        defaultFile.attackUpgradesBought = 0;
        defaultFile.speedUpgradesBought = 0;
        defaultFile.skillDurationUpgradesBought = 0;
        defaultFile.skillCooldownUpgradesBought = 0;
        defaultFile.bulletFireRateUpgradesBought = 0;
        defaultFile.doubleTapUpgradesBought = 0;
        defaultFile.tripleShotUpgradesBought = 0;
        defaultFile.coinMultiplierUpgradesBought = 0;

        return defaultFile;
    }

    //Porque solo existe 1 solo tipo de cada uno no hay que diferenciar pero queda hecho para hacer extensible si hace falta
    
    //Esto hay que evitarlo (CONSIGNA)
    private void LoadMiscResources()
    {
        upgradedExplosionSprite = Resources.Load<GameObject>("Prefabs/Explosion/Explosion");
    }
    private void LoadWeaponResources()
    {
        upgradedPlayerProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/PlayerProjectile");
    }
}
