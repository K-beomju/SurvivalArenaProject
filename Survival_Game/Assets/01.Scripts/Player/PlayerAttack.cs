using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius;

    private GameObject enemy;

    private IBowAnimation IbowAnim;
    private BowRotation bowRot;

    private void Awake()
    {
        IbowAnim = GetComponentInChildren<IBowAnimation>();
        bowRot = GetComponentInChildren<BowRotation>();
    }

    private void Update()
    {
        IbowAnim.BowAttackAnim(FindNearestObjectByEnemy() && !GameManager.IsPlayerDead());
        bowRot.AngleToWardsEnemy(enemy != null && enemy.activeSelf && !GameManager.IsPlayerDead(), enemy);
    }

    public bool FindNearestObjectByEnemy()
    {
        var objects = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));
        if(objects.Length>0){
            var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.transform.position);
            })
            .First();

            if (neareastObject.gameObject.activeSelf)
                enemy = neareastObject.gameObject;
            else
                enemy = null;

            return true;
        }
        enemy = null;
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
