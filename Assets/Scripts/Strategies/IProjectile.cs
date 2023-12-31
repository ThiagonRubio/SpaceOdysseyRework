using UnityEngine;
public interface IProjectile : IPoolable
{
    ProjectileStats ProjectileStats { get; }
    float TravelSpeed { get; }
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    IWeapon Owner { get; }
    void SetOwner(IWeapon weapon);
    void OnCollisionEnter2D(Collision2D col);
}
