using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageableComponent : Actor, IDamageable
{
    //---IDAMAGEABLE-----
    public float MaxHealth => ActorStats.MaxHealth;
    public float ActualHealth => actualHealth;

    //---IDAMAGEABLE PRIVATE-----
    private float actualHealth;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Start()
    {
        actualHealth = ActorStats.MaxHealth;
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void TakeDamage(float damageAmount)
    {
        actualHealth -= damageAmount;

        if (actualHealth <= 0)
            Die();
    }

    public void Die()
    {
        print("I died, que triste. Saludos.");
    }

    public void Revive()
    {
        throw new System.NotImplementedException();
    }
}