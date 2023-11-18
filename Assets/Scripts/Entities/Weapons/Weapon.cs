using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public GameObject GameObject => this.GameObject;
    public ObjectPool ObjectPool => _projectilesPool;
    public AbstractFactory<IPoolable> CreatorFactory => _projectileFactory;

    public WeaponStats Stats => weaponStats;
    public Projectile Projectile => Stats.Projectile;
    public Transform[] ProjectileSpawnPoints => spawnPoints;
    public float FireRate => Stats.FireRate;
    public float Damage => Stats.Damage;
    public int MaxPoolableObjects => Stats.MaxPoolableObjects;

    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] private Transform[] spawnPoints;
    
    private ObjectPool _projectilesPool;
    private ProjectileFactory _projectileFactory;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            //Esto es super cabezoide pero bue, hay que esperar que cargue el player antes del arma
            StartCoroutine(RetrievePlayerWeaponSavedData());
        }
    }
    private void Start()
    {
        _projectilesPool = GetComponent<ObjectPool>();
        _projectileFactory = new ProjectileFactory(this, Projectile, MaxPoolableObjects);
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################
    public void UseWeapon()
    {
        IProjectile newProjectile = _projectileFactory.CreateObject(this);
        newProjectile.SetOwner(this);
        
        SoundManager.Instance.ReproduceSound(AudioConstants.ProyectileShot, 1);
    }
    private IEnumerator RetrievePlayerWeaponSavedData()
    {
        yield return new WaitForFixedUpdate();
        PlayerSavedStats playerSavedStats = GetComponentInParent<PlayerSavedStats>();

        if (playerSavedStats != null)
        {
            weaponStats = playerSavedStats.GetPlayerWeaponStats();
        }
        else Debug.LogWarning("Missing UpgradedStats Component in Player Weapon's Parent");
    }
}
