using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class LivingEntity : MonoBehaviour, IDamageable
{
    public float initHealth;
    public float health { get; protected set; }

    public bool dead { get; protected set; }

    public event Action OnDeath;

    public SpriteRenderer sr { get; set; }

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    protected virtual void OnEnable()
    {
        dead = false;
        health = initHealth;
    }

    public virtual void OnDamage(float damage)
    {
        if (dead) return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(float value)
    {
        if (dead) return;
        health += value;
    }

    public virtual void Die()
    {
        if (!dead)
        {
            OnDeath?.Invoke();
            dead = true;
        }
    }

    
}
