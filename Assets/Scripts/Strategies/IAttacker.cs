using UnityEngine;
public interface IAttacker : IPoolOwner
{
    Projectile Projectile { get; }
    Transform[] ProjectileSpawnPoints { get; }
    float AttackCooldownTimer { get; }
    float FireRate { get; }
    float Damage { get; }
    void Attack();
}
