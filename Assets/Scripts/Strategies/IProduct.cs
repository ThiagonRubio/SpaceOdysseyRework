using UnityEngine;

public interface IProduct
{
    GameObject GameObject { get; }
    IProduct Clone();
}
