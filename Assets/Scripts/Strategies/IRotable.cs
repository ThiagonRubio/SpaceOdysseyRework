using UnityEngine;
public interface IRotable
{
    int RotationSpeed { get; }
    void Rotate();
}