using UnityEngine;
public interface IRotable
{
    float rotationSpeed { get; }
    void Rotate();
}