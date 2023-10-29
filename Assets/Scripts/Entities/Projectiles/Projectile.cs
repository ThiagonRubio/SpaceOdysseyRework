using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    public GameObject GameObject => this.gameObject;
    public ProjectileStats ProjectileStats => _projectileStats;
    public float TravelSpeed => ProjectileStats.TravelSpeed;
    public float LifeTime => ProjectileStats.LifeTime;
    public LayerMask HitteableLayer => ProjectileStats.HitteableLayer;
    public IWeapon Owner => owner;

    [SerializeField] private ProjectileStats _projectileStats;
    private IWeapon owner;
    private float currentLifeTime;

    private void Start()
    {
        currentLifeTime = LifeTime;
    }

    private void Update()
    {
        Travel();

        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            OnPoolableObjectDisable();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & HitteableLayer) != 0)
        {
            if (collision.collider.gameObject.TryGetComponent(out IDamageable hitEntity))
            {
                hitEntity.TakeDamage(owner.Stats.Damage);
            }

            OnPoolableObjectDisable();
        }
    }

    private void Travel()
    {
        transform.position += transform.right * (Time.deltaTime * ProjectileStats.TravelSpeed);
    }

    public void OnPoolableObjectDisable()
    {
        currentLifeTime = LifeTime;
        gameObject.SetActive(false);
    }
    public IProduct Clone()
    {
        return Instantiate(this);
    }
    public void SetOwner(IWeapon weapon) => owner = weapon;
}
