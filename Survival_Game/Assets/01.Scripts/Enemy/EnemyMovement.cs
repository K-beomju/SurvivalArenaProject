using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;

    private SpriteRenderer sr;
    private EnemyHealth eh;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        eh = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        moveSpeed = 0.5f;//Random.Range(1f, 1.5f);
        StartCoroutine(TrackingPlayerCo());
    }


    private IEnumerator TrackingPlayerCo()
    {
        while (!GameManager.IsPlayerDead() && !eh.dead)
        {
            Vector3 dir = GameManager.playerTrm().position - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);

            sr.flipX = dir.x < 0 ? true : false;

            yield return null;
        }
    }

}
