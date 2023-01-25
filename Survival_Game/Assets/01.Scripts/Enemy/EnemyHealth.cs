using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : LivingEntity
{
    #region 피격 변수 
    private bool isHit = false;
    private float hitTime = 0f;                         // 코루틴을 사용할 때보다 성능 향샹 
    private float hitColorDuration = 0.1f;
    private Renderer ren;
    private MaterialPropertyBlock materialPropertyBlock; // 사용하면 색상을 변경할 때마다 기존의 재질을 새로 생성하지 않아도 되기 때문에 메모리 사용량 줄임 
    #endregion 

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);

        #region 피격 Renderer 이벤트 
        isHit = true;
        hitTime = Time.time;
        materialPropertyBlock.SetColor("_Color", Color.red);
        ren.SetPropertyBlock(materialPropertyBlock);
        #endregion
    }

    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);   //TODO : POOL
    }

     private void Update()
    {
        if (hitTime + hitColorDuration <= Time.time && isHit)
        {
            materialPropertyBlock.SetColor("_Color", Color.white);
            ren.SetPropertyBlock(materialPropertyBlock);
            hitTime = 0f;
            isHit = false;
        }
    }


}
