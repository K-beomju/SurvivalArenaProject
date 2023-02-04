using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSkill : SkillParent
{
    public int attackRadius;

    public void CheckAttackEnemy()
    {
        var objects = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));

        foreach(var obj in objects)
        {
            if(obj != null)
            {
                EnemyHealth eh = obj.GetComponent<EnemyHealth>();
                eh.OnDamage(10);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }


}
