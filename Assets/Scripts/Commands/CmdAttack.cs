using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdAttack : ICommand
{
    private IWeapon[] equippedWeapons;

    //----CONSTRUCTOR----
    public CmdAttack(IWeapon[] equippedWeapons)
    {
        this.equippedWeapons = equippedWeapons;
    }

    //----ICOMMAND IMP.----
    public void Execute()
    {
        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            equippedWeapons[i].UseWeapon();
        }
    }
}
