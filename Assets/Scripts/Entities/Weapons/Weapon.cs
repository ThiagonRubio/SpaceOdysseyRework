using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public GameObject GameObject => this.gameObject;
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
        Invoke("InitializeFactory",0.02f);
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################
    private void InitializeFactory()
    {
        _projectileFactory = new ProjectileFactory(this, Projectile, MaxPoolableObjects);
    }
    
    public void UseWeapon()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            IProjectile newProjectile = _projectileFactory.CreateObject(this);
            newProjectile.GameObject.transform.position = spawnPoints[i].transform.position;
            newProjectile.GameObject.transform.rotation = spawnPoints[i].transform.rotation;
            newProjectile.SetOwner(this);
        }
        
        SoundManager.Instance.ReproduceSound(AudioConstants.ProyectileShot, 1);
    }
    public IEnumerator RetrievePlayerWeaponSavedData()
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
