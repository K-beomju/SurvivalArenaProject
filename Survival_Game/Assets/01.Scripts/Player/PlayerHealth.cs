using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    [SerializeField] private HealthBar hpBar;
    private float damageDelay = 0.1f;
    private float nextDamageTime;


    private void Start() 
    {
        hpBar.SetFill(health, initHealth);
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        hpBar.SetFill(health, initHealth);
    }

    public override void Die()  
    {
        base.Die();
        
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(Time.time > nextDamageTime)
            {
                OnDamage(1f);
                nextDamageTime = Time.time + damageDelay;
            }
        }
    }

}
