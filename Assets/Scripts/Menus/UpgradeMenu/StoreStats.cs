using UnityEngine;

[CreateAssetMenu(fileName = "StoreStats", menuName = "Stats/StoreStats", order = 0)]
public class StoreStats : ScriptableObject
{
    [field: SerializeField] public int[] HpPrices { get; private set; }
    [field: SerializeField] public int[] AttackPrices { get; private set; }
    [field: SerializeField] public int[] SpeedPrices { get; private set; }
    [field: SerializeField] public int[] SkillDurationPrices { get; private set; }
    [field: SerializeField] public int[] SkillCooldownPrices { get; private set; }
    [field: SerializeField] public int[] BulletFireRatePrices { get; private set; }
    [field: SerializeField] public int[] DoubleTapPrices { get; private set; }
    [field: SerializeField] public int[] TripleShotPrices { get; private set; }
    [field: SerializeField] public int[] CoinMultiplierPrices { get; private set; }
    
    [field: SerializeField] public float[] HpValues { get; private set; }
    [field: SerializeField] public float[] AttackValues { get; private set; }
    [field: SerializeField] public float[] SpeedValues { get; private set; }
    [field: SerializeField] public float[] SkillDurationValues { get; private set; }
    [field: SerializeField] public float[] SkillCooldownValues { get; private set; }
    [field: SerializeField] public float[] BulletFireRateValues { get; private set; }
    [field: SerializeField] public float[] DoubleTapValues { get; private set; }
    [field: SerializeField] public float[] TripleShotValues { get; private set; }
    [field: SerializeField] public float[] CoinMultiplierValues { get; private set; }
}
