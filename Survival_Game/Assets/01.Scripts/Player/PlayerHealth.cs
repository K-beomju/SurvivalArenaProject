using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    [SerializeField] private HealthBar hpBar;

    private void Start() 
    {
        hpBar.SetFill(health, initHealth);
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        hpBar.SetFill(health, initHealth);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            OnDamage(1f);
        }    
    }

}
