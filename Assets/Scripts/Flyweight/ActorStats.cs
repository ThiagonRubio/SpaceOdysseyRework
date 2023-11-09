using UnityEngine;

[CreateAssetMenu(fileName = "ActorStats", menuName = "Stats/ActorStats", order = 0)]
public class ActorStats : ScriptableObject
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public GameObject Explosion { get; private set; }
}