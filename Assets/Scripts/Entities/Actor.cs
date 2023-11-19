using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Actor : MonoBehaviour
{
    //----PUBLIC PROPERTIES----
    public ActorStats ActorStats => stats;
    
    //----PROTECTED PROPERTIES----
    protected Animator entityAnim;
    protected Rigidbody2D entityRb;

    //----PRIVATE PROPERTIES----
    [SerializeField] private ActorStats stats;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    protected virtual void Awake()
    {
        entityAnim = GetComponent<Animator>();
        entityRb = GetComponent<Rigidbody2D>();

        if (gameObject.CompareTag("Player"))
        {
            PlayerSavedStats playerSavedStats = GetComponent<PlayerSavedStats>();
            stats = playerSavedStats.GetPlayerStats();
        }
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

}