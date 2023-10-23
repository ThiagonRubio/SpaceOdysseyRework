using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats", order = 0)]
public class WeaponStats : ScriptableObject
{
    [field: SerializeField] public Projectile Projectile { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public int MaxPoolableObjects { get; private set; }
}
