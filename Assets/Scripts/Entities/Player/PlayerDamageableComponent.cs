using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageableComponent : Actor, IDamageable, IListener
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
        EventManager.Instance.AddListener(EventConstants.ShieldEffect, this);
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
        EventManager.Instance.DispatchSimpleEvent(EventConstants.PlayerDeath);
    }

    public void Revive()
    {
        throw new System.NotImplementedException();
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.ShieldEffect)
        {
            actualHealth++;
            if (actualHealth > 10) //Tope definido en el juego original
            {
                actualHealth = 10;
            }
        }
    }
}