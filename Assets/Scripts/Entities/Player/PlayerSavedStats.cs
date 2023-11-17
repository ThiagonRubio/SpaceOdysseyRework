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

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    private void Awake()
    {
        // if (SaveSystem.LoadPlayerStats() != null)
        // {
        //     PlayerSavedStats var = SaveSystem.LoadPlayerStats();
        //     AssignValues(var);
        // }
        // else
        // {
        //    SaveSystem.SavePlayerStats(this);
        // }
    }

    public ActorStats LoadSavedPlayerStats()
    {
        ActorStats playerStats = new ActorStats(upgradedMaxHealth, upgradedSpeed, upgradedExplosionSprite);
        return playerStats;
    }
    public WeaponStats LoadSavedWeaponStats()
    {
        WeaponStats playerDefaultWeapon = new WeaponStats(upgradedPlayerProjectile, upgradedBulletFireRate, upgradedAttack, 15);
        return playerDefaultWeapon;
    }

    private void AssignValues(PlayerSavedStats stats)
    {
        upgradedMaxHealth = stats.upgradedMaxHealth;
        upgradedAttack = stats.upgradedAttack;
        upgradedSpeed = stats.upgradedSpeed;
        upgradedSkillDuration = stats.upgradedSkillDuration;
        upgradedSkillCooldown = stats.upgradedSkillCooldown;
        upgradedBulletFireRate = stats.upgradedBulletFireRate;
        upgradedDoubleTapDuration = stats.upgradedDoubleTapDuration;
        upgradedTripleShotDuration = stats.upgradedTripleShotDuration;
        upgradedCoinMultiplier = stats.upgradedCoinMultiplier;
        upgradedExplosionSprite = stats.upgradedExplosionSprite;
        upgradedPlayerProjectile = stats.upgradedPlayerProjectile;
    }
}
