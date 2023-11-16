using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSavedStats : MonoBehaviour
{
    public float SkillDuration => upgradedSkillDuration;
    public float SkillCooldown => upgradedSkillCooldown;

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
    public void SaveStats()
    {
        //Aca guardas los valores cuando el player haga save
    }
    public void LoadStats()
    {
        //Aca reescribir los valores que sacas del JSON con todas las stats guardadas, y llamar este metodo antes de
        //crear los SO con los metodos de abajo
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
}
