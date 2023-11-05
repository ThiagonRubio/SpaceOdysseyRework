using UnityEngine;
public interface IPowerUp : IMoveable, IProduct
{
    void Effect();
    void OnCollisionEnter2D(Collision2D other);
}
