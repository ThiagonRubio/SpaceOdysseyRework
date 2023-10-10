using System;
using UnityEngine;

public class Actor : MonoBehaviour, IMoveable, IDamageable
{
    public float Speed => stats.MovementSpeed;
    public float MaxHealth => stats.MaxHealth;
    public float ActualHealth => _actualHealth;

    [SerializeField] private ActorStats stats;
    private float _actualHealth;

    private CmdDie _commandDie;

    private void Start()
    {
        InitializeCommands();
    }

    public void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
    
    public void TakeDamage(float damageAmount)
    {
        _actualHealth -= damageAmount;
        if (_actualHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void Revive()
    {
        gameObject.SetActive(true);
    }

    private void InitializeCommands()
    {
        _commandDie = new CmdDie(this);
    }
}