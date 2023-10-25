using UnityEngine;
public interface IAttacker : ICommandImplementer
{
    CmdAttack CmdAttack { get; }
    IWeapon[] Weapon { get; }

    float AttackCooldownTimer { get; }
    void SetWeaponToUse(IWeapon[] weaponsToUse);
    void Attack();
}
