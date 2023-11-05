using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerStats", menuName = "Stats/SpawnerStats", order = 0)]

public class SpawnerControllerStats : ScriptableObject
{
    [field: SerializeField] public float StartingCreationCooldown { get; private set; }
    [field: SerializeField] public float CreationCooldownDecreasePerBoss { get; private set; }
    
    [field: SerializeField] public int StartingDifficulty { get; private set; }
    
    [field: SerializeField] public int EnemiesBetweenBosses { get; private set; }
    [field: SerializeField] public int EnemiesUntilObstacles { get; private set; }
    [field: SerializeField] public int ObstacleChancePercentage { get; private set; }
}