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
    public IAttacker Owner => owner;

    [SerializeField] private ProjectileStats _projectileStats;
    private IAttacker owner;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & HitteableLayer) != 0)
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                //Acá iría el comando de damage.
            }

            OnPoolableObjectDisable();
        }
    }

    private void Travel()
    {
        transform.position += transform.right * Time.deltaTime * ProjectileStats.TravelSpeed;
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
    public void SetOwner(IAttacker attacker) => owner = attacker;
}
