using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : LivingEntity
{
    [SerializeField] private float dustEtScale = 1;

    private SpriteRenderer sr;
    private WaitForSeconds hitDelay = new WaitForSeconds(.1f);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void OnDamage(float damage)
    {
        if (dead) return;
        base.OnDamage(damage);
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            other.gameObject.SetActive(false);
            OnDamage(1);
        }
    }

    public override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }


}
