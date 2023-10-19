using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class ActorEntity : MonoBehaviour
{
    //public EntityStats EntityStats => entityStats;

    //----PROTECTED PROPERTIES----
    //[SerializeField] protected EntityStats entityStats;

    protected Animator entityAnim;
    protected Rigidbody2D entityRb;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    protected virtual void Awake()
    {
        entityAnim = GetComponent<Animator>();
        entityRb = GetComponent<Rigidbody2D>();
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################


}