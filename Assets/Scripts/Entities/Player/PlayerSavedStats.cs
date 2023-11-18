using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSavedStats : MonoBehaviour
{
    public float SkillDuration => upgradedSkillDuration;
    public float SkillCooldown => upgradedSkillCooldown;
    public float UpgradedCoinMultiplier => upgradedCoinMultiplier;
    public float MoneyStored => moneyStored;
    public PlayerSavedStats LoadedSessionPlayerData => loadedSessionData;

    //----PRIVATE VARS----
    private PlayerSavedStats loadedSessionData;

    [SerializeField] private float upgradedMaxHealth;
    [SerializeField] private float upgradedAttack;
    [SerializeField] private float upgradedSpeed;
    [SerializeField] private float upgradedSkillDuration;
    [SerializeField] private float upgradedSkillCooldown;
    [SerializeField] private float upgradedBulletFireRate;
    [SerializeField] private float upgradedDoubleTapDuration;
    [SerializeField] private float upgradedTripleShotDuration;
    [SerializeField] private float upgradedCoinMultiplier;
    [SerializeField] private GameObject upgradedExplosionSprite;
    [SerializeField] private Projectile upgradedPlayerProjectile;
    [SerializeField] private float moneyStored;

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    private void Awake()
    {
        //Para Forzar a que se sobrescriba todos los valores edita el .txt del json directamente

        if (SaveSystem.GetIfSaveFileExists() == false)
        {
            SaveData();
            Debug.LogWarning("Player Save doesn't exist. Creating new one.");
        }
        else 
        {
            SaveSystem.LoadFromJson(this);
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
    public void SaveData()
    {
        loadedSessionData = this;
        SaveSystem.SaveToJson(loadedSessionData);
    }
    public void SaveMoneyData(float moneyToAdd)
    {
        moneyStored += moneyToAdd;
        SaveData();
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
