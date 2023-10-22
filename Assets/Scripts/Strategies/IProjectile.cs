using UnityEngine;
public interface IProjectile : IMoveable, IProduct
{
    IAttacker Owner { get; }
    void OnTriggerEnter2D(Collider2D collision);
}
