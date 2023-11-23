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
    [SerializeField] private HealthBarFacade healthBarUIFacade;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Start()
    {
        actualHealth = ActorStats.MaxHealth;
        if (actualHealth > 10)
            actualHealth = 10;
        healthBarUIFacade.UpdateHealth();
        EventManager.Instance.AddListener(EventConstants.MedicKitEffect, this);
        Invoke("CheckHP",0.1f);
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    private void CheckHP()
    {
        if(actualHealth > 1)
            healthBarUIFacade.ApagarMarcoRojoPordefecto();
    }
    
    public void TakeDamage(float damageAmount)
    {
        actualHealth -= damageAmount;

        entityAnim.SetTrigger(AnimationConstants.TookDamage);
        SoundManager.Instance.ReproduceSound(AudioConstants.TookDamage, 1);
        
        healthBarUIFacade.UpdateHealth();
        
        if(actualHealth == 1)
            entityAnim.SetBool(AnimationConstants.Player1Hp, true);
        
        if (actualHealth <= 0)
            Die();
    }

    public void Die()
    {
        EventManager.Instance.DispatchSimpleEvent(EventConstants.PlayerDeath);
        Instantiate(ActorStats.Explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.MedicKitEffect)
        {
            actualHealth++;
            healthBarUIFacade.UpdateHealth();
            if(actualHealth > 1)
                entityAnim.SetBool(AnimationConstants.Player1Hp, false);
            if (actualHealth > 10) //Tope definido en el juego original
            {
                actualHealth = 10;
            }
        }
    }
}