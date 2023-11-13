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

        entityAnim.SetTrigger(AnimationConstants.TookDamage);
        SoundManager.Instance.ReproduceSound(AudioConstants.TookDamage, 1);
        
        if(actualHealth == 1)
            entityAnim.SetBool(AnimationConstants.Player1Hp, true);
        
        if (actualHealth <= 0)
            Die();
    }

    public void Die()
    {
        print("I died, que triste. Saludos.");
        EventManager.Instance.DispatchSimpleEvent(EventConstants.PlayerDeath);
        Instantiate(ActorStats.Explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.ShieldEffect)
        {
            actualHealth++;
            if(actualHealth > 1)
                entityAnim.SetBool(AnimationConstants.Player1Hp, false);
            if (actualHealth > 10) //Tope definido en el juego original
            {
                actualHealth = 10;
            }
        }
    }
}