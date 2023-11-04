using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerStats", menuName = "Stats/EnemySpawnerStats", order = 0)]

public class EnemySpawnerControllerStats
{
    [field: SerializeField] public float StartingCreationCooldown { get; private set; }
    [field: SerializeField] public float CreationCooldownDecreasePerBoss { get; private set; }
    
    [field: SerializeField] public int StartingDifficulty { get; private set; }
    
    [field: SerializeField] public int EnemiesBetweenBosses { get; private set; }
    [field: SerializeField] public int EnemiesUntilObstacles { get; private set; }
    [field: SerializeField] public int ObstacleChancePercentage { get; private set; }
}