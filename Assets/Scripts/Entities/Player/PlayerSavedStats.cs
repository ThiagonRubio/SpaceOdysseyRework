using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSavedStats : MonoBehaviour
{
    public float SkillDuration => upgradedSkillDuration;
    public float SkillCooldown => upgradedSkillCooldown;
    public float UpgradedCoinMultiplier => upgradedCoinMultiplier;
    public float MoneyStored => moneyStored;
    public PlayerSavedStats CurrentSessionPlayerData => sessionData;
    public PlayerUpgradesBoughtStats UpgradesBoughtData => upgradesBoughtStats;
    
    //----PRIVATE VARS----
    private PlayerSavedStats sessionData;

    [SerializeField, HideInInspector] private float upgradedMaxHealth;
    [SerializeField, HideInInspector] private float upgradedAttack;
    [SerializeField, HideInInspector] private float upgradedSpeed;
    [SerializeField, HideInInspector] private float upgradedSkillDuration;
    [SerializeField, HideInInspector] private float upgradedSkillCooldown;
    [SerializeField, HideInInspector] private float upgradedBulletFireRate;
    [SerializeField, HideInInspector] private float upgradedDoubleTapDuration;
    [SerializeField, HideInInspector] private float upgradedTripleShotDuration;
    [SerializeField, HideInInspector] private float upgradedCoinMultiplier;
    [SerializeField, HideInInspector] private GameObject upgradedExplosionSprite;
    [SerializeField, HideInInspector] private Projectile upgradedPlayerProjectile;
    [SerializeField, HideInInspector] private float moneyStored;
    [SerializeField, HideInInspector] private PlayerUpgradesBoughtStats upgradesBoughtStats;

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
        playerDefaultWeapon.ConstructWeaponStats(upgradedPlayerProjectile, upgradedBulletFireRate, upgradedAttack, 15);
        return playerDefaultWeapon;
    }
    public void SaveMoneyData(float moneyToAdd)
    {
        moneyStored += moneyToAdd;
        SaveData(this);
    }
    private void SaveData(PlayerSavedStats sessionData)
    {
        SaveSystem.SaveToJson(sessionData);
    }
    private PlayerSavedStats InitDefaultSaveFile()
    {
        PlayerSavedStats defaultFile = this;

        defaultFile.upgradedMaxHealth = 1;
        defaultFile.upgradedAttack = 1;
        defaultFile.upgradedSpeed = 250;
        defaultFile.upgradedSkillDuration = 1;
        defaultFile.upgradedSkillCooldown = 10;
        defaultFile.upgradedBulletFireRate = 0.5f;
        defaultFile.upgradedDoubleTapDuration = 2;
        defaultFile.upgradedTripleShotDuration = 2;
        defaultFile.upgradedCoinMultiplier = 0.2f;
        defaultFile.moneyStored = 0;
        defaultFile.upgradedExplosionSprite = Resources.Load<GameObject>("Prefabs/Explosion/Explosion");
        defaultFile.upgradedPlayerProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/PlayerProjectile");
        defaultFile.upgradesBoughtStats.InitDefaultStats();
        return defaultFile;
    }
    //Porque solo existe 1 solo tipo de cada uno no hay que diferenciar pero queda hecho para hacer extensible si hace falta
    private void LoadMiscResources()
    {
        upgradedExplosionSprite = Resources.Load<GameObject>("Prefabs/Explosion/Explosion");
    }
    private void LoadWeaponResources()
    {
        upgradedPlayerProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/PlayerProjectile");
    }
}
