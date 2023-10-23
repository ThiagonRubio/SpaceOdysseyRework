using UnityEngine;
public interface IProjectile : IProduct
{
    ProjectileStats ProjectileStats { get; }
    float TravelSpeed { get; }
    float LifeTime { get; }
    LayerMask HitteableLayer { get; }
    IAttacker Owner { get; }
    void OnTriggerEnter2D(Collider2D other);
    void SetOwner(IAttacker attacker);
}
