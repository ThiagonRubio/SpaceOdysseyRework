using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolOwner
{
    GameObject GameObject { get; }
    ObjectPool ObjectPool { get; }
    AbstractFactory<IPoolable> CreatorFactory { get; }
}
