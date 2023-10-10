public interface IDamageable
{
    float MaxHealth { get; }
    float ActualHealth { get; }
    void TakeDamage(float damageAmount);
    void Die();
}