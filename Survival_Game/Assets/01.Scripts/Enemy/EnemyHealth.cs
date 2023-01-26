using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : LivingEntity
{
    #region 피격 변수 
    private bool isHit = false;
    private float hitTime = 0f;                         // 코루틴을 사용할 때보다 성능 향샹 
    private float hitColorDuration = 0.1f;
    #endregion 

    public EnemyAbilities enemyAb;

    protected override void OnEnable()
    {
        base.OnEnable();
        health = enemyAb.health;
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);

        #region 피격 Renderer 이벤트 
        isHit = true;
        hitTime = Time.time;
        sr.color = Color.red;
        #endregion
    }

    public override void Die()
    {
        base.Die();
        gameObject.SetActive(false);  
        sr.color = Color.white;
    }

    private void Update()
    {
        if (hitTime + hitColorDuration <= Time.time && isHit)
        {
            sr.color = Color.white;
            hitTime = 0f;
            isHit = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ph.OnDamage(enemyAb.attack);
        }
    }


}
