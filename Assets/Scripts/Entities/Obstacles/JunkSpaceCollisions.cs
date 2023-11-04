using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpaceCollisions : MonoBehaviour
{
    [SerializeField] private float crashDamage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.TryGetComponent<Enemy>(out Enemy enemyHit)) 
        {
            enemyHit.Die();
        }
        if (other.gameObject.CompareTag("Projectile") && other.gameObject.TryGetComponent<IProjectile>(out IProjectile projectileHit)) 
        {
            projectileHit.OnPoolableObjectDisable();
        }
        if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<IDamageable>(out IDamageable damagedPlayer)) 
        {
            damagedPlayer.TakeDamage(crashDamage);
        }
    }
}
