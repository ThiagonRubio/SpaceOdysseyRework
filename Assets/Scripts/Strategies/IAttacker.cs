using UnityEngine;
public interface IAttacker
{
    GameObject Projectile { get; }
    Transform[] ProjectileSpawnPoints { get; }
    float Cooldown { get; }
    float Damage { get; }
    void Attack();
}
