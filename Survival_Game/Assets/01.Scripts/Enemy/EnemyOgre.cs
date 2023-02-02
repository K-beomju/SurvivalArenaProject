using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : Enemy
{
    private bool isCheck = false;
    private Enemy babyEnemy;

    private void OnEnable()
    {
        anim.enabled = true;
        StartCoroutine(base.TrackingPlayerCo());
    }

    public override void Attack()
    {
        if (!isCheck)
        {
            StartCoroutine(SpawnOrc());
            isCheck = true;
        }
    }

    private IEnumerator SpawnOrc()
    {
        while (IsCheckPlayer() || !GameManager.IsPlayerDead())
        {
            babyEnemy = PoolManager.GetEnemyObject(EnemyType.Baby);
            babyEnemy.transform.position = transform.position + new Vector3(Random.Range(-1,2), Random.Range(-1,2));
            babyEnemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }
}
