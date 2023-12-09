using UnityEngine;
public interface IAttacker
{
    CmdAttack CmdAttack { get; }
    IWeapon[] Weapon { get; }

    float AttackCooldownTimer { get; }
    void SetWeaponToUse(IWeapon[] weaponsToUse);
    void Attack();
}
