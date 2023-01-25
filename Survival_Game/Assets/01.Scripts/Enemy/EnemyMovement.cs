using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private float moveSpeed = 0.5f;
    private Vector3 playerPos;
    private Vector3 direction;
    private EnemyHealth eh;

    private void OnEnable() 
    {
        StartCoroutine(TrackingPlayerCo());
    }

    public IEnumerator TrackingPlayerCo()
    {
        while (!GameManager.IsPlayerDead() || !enemyHealth.dead)
        {
            playerPos = GameManager.playerTrm().position;
            direction = (playerPos - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            sr.flipX = direction.x < 0 ? true : false;
            yield return null;
        }
    }

}
