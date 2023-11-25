using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour, IWeapon
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
    
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask hitteableLayer;
    private ObjectPool _projectilesPool;
    private ProjectileFactory _projectileFactory;

    private RaycastHit2D rcHit;
    void Start()
    {
        _projectilesPool = GetComponent<ObjectPool>();
        _projectileFactory = new ProjectileFactory(this, Projectile, MaxPoolableObjects);
    }

    void Update()
    {
        rcHit = Physics2D.Raycast(spawnPoints[0].transform.position, Vector2.left, raycastDistance, hitteableLayer);
    }
    
    public void UseWeapon()
    {
        if (rcHit)
        {
            if (rcHit.transform.CompareTag("Player"))
            {
                IProjectile newProjectile = _projectileFactory.CreateObject(this);
                newProjectile.SetOwner(this);
            }
        }
    }
}
