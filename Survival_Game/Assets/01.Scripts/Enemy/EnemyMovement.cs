using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = 0.5f;
        StartCoroutine(TrackingPlayerCo());
    }

    private IEnumerator TrackingPlayerCo()
    {
        while (!GameManager.IsPlayerDead() && !enemyHealth.dead)
        {
            Vector3 dir = GameManager.playerTrm().position - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

            sr.flipX = dir.x < 0 ? true : false;
            yield return null;
        }
    }

}
