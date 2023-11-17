using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreStats", menuName = "Stats/ScoreStats", order = 0)]
public class ScoreStats : ScriptableObject
{
    [field: SerializeField] public float NukeScore { get; private set; }
    [field: SerializeField] public float AsteroidScore { get; private set; }
    [field: SerializeField] public float RedShipScore { get; private set; }
    [field: SerializeField] public float PurpleShipScore { get; private set; }
    [field: SerializeField] public float YellowShipScore { get; private set; }
    [field: SerializeField] public float RedBosscore { get; private set; }
}
