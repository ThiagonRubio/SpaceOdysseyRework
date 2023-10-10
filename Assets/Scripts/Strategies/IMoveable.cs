using UnityEngine;
public interface IMoveable
{
    float Speed { get; }
    void Move(Vector3 direction);
}

