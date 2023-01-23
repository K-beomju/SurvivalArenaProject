using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius;

    public GameObject enemy;

    private BowAnimation bowAnim;

    private void Awake()
    {
        bowAnim = GetComponentInChildren<BowAnimation>();
    }

 

    private void Update()
    {
        bowAnim.BowAttackAnim(FindNearestObjectByEnemy() && !GameManager.IsPlayerDead());
    }

    public bool FindNearestObjectByEnemy()
    {
        try
        {

            var objects = GameObject.FindGameObjectsWithTag("Enemy").ToList();

            var neareastObject = objects
                .OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.transform.position);
            })
            .FirstOrDefault();

            Vector3 offset = neareastObject.transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;

            bool inRadiusEnemy = sqrLen < Mathf.Pow(attackRadius, 2) ? true : false;


            if (inRadiusEnemy && neareastObject.activeSelf)
                enemy = neareastObject;
            else
                enemy = null;


            return inRadiusEnemy;
        }
        catch (NullReferenceException ne)
        {
            //print(ne);
            enemy = null;
            return false;
        }


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
