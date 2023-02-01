using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public EnemyHealth enemyHealth { get; set; }
    public EnemyMovement enemyMovement { get; set; }

    public Animator anim { get; set; }
    public Transform playerTrm { get; set; }

    private Vector3 direction;


    protected virtual void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
    }

    public virtual IEnumerator TrackingPlayerCo()
    {
        playerTrm = GameManager.playerTrm();

        while (!GameManager.IsPlayerDead())
        {
            direction = (playerTrm.position - transform.position).normalized;
            transform.position += direction * enemyHealth.enemyAb.speed * Time.deltaTime;

            Attack();

            enemyHealth.sr.flipX = direction.x < 0 ? true : false;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        anim.enabled = false;
    }

    public virtual void Attack()
    {
    }


}
