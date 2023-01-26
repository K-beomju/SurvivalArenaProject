using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private float moveSpeed = 1f;
    private Transform playerTrm;
    private Vector3 direction;

    private void OnEnable() 
    {
        playerTrm = GameManager.playerTrm();
        StartCoroutine(TrackingPlayerCo());
    }

    public IEnumerator TrackingPlayerCo()
    {
        while (!GameManager.IsPlayerDead())
        {
            direction = (playerTrm.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            enemyHealth.sr.flipX = direction.x < 0 ? true : false;
            yield return null;
        }
    }

}
