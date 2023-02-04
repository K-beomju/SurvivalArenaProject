using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyArrowSkill : SkillParent
{
    private void Start()
    {
        StartCoroutine(DetativeSkillCo());    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            eh.OnDamage(10);
            gameObject.SetActive(false);
        }
    }


}
