using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileStats", menuName = "Stats/ProjectileStats", order = 0)]
public class ProjectileStats : ScriptableObject
{
    [field: SerializeField] public float LifeTime { get; private set; }
    [field: SerializeField] public LayerMask HitteableLayer { get; private set; }
    [field: SerializeField] public float TravelSpeed { get; private set; }
}
