using UnityEngine;
public interface IAttacker 
{
    IWeapon[] Weapon { get; }

    float AttackCooldownTimer { get; }
    
    void Attack();
}
