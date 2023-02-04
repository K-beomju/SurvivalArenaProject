using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    [SerializeField] private HealthBar hpBar;
    [SerializeField] private HitEffect hitEffect;

    public bool isHit { get; set; } = false;
    public bool DebugMode = false;
    private float damageDelay = 0.5f;
    private float nextDamageTime;


    private void Start()
    {
        hpBar.SetFill(health, initHealth);
    }

    public override void OnDamage(float damage)
    {
        if (!isHit || GameManager.IsPlayerDead() || DebugMode) return;

        base.OnDamage(damage);
        hpBar.SetFill(health, initHealth);
        hitEffect.HitScreen();
        isHit = false;

    }

    public override void RestoreHealth(float value) 
    {
        base.RestoreHealth(value);
        hpBar.SetFill(health, initHealth);

    }

    public override void Die()
    {
        base.Die();

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CheckHitDelay();
        }
    }

    public void CheckHitDelay()
    {
        if (Time.time > nextDamageTime && !isHit)
        {
            isHit = true;
            nextDamageTime = Time.time + damageDelay;
        }
    }


}
