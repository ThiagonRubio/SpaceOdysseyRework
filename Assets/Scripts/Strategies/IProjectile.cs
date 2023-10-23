using UnityEngine;
public interface IProjectile : IPoolable
{
    ProjectileStats ProjectileStats { get; }
    float TravelSpeed { get; }
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    IWeapon Owner { get; }
    void OnTriggerEnter2D(Collider2D other);
    void SetOwner(IWeapon weapon);
}
