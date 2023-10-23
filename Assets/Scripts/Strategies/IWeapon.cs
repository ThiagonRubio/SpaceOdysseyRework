using UnityEngine;

public interface IWeapon : IPoolOwner
{
    WeaponStats Stats { get; }
    Projectile Projectile { get; }
    Transform[] ProjectileSpawnPoints { get; }
    float FireRate { get; }
    float Damage { get; }
    int MaxPoolableObjects { get; }
    
    void UseWeapon();
}
