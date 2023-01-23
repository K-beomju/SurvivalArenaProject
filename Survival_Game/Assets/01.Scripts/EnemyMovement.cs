using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed;

    private SpriteRenderer sr;
    private EnemyHealth eh;
    private Animator anim;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        eh = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveSpeed = Random.Range(1f, 1.5f);
        StartCoroutine(TrackingPlayerCo());
        anim.enabled = true;
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

        anim.enabled = false;
    }

}
