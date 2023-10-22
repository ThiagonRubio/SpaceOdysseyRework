using UnityEngine;
public interface IPowerUp : IMoveable, IProduct
{
    void Effect();
    void OnTriggerEnter2D(Collider2D collision);
}
