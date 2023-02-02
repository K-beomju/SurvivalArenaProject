using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : Enemy
{
    [SerializeField] private ShamanBullet bullet;
    private bool isCheck = false;

    private void OnEnable()
    {
        anim.enabled = true;
        StartCoroutine(base.TrackingPlayerCo());
    }

    public override void Attack()
    {
        if (IsCheckPlayer())
        {
            if (!isCheck)
            {
                StartCoroutine(FireBullet());
                isCheck = true;
            }
        }
    }

    private IEnumerator FireBullet()
    {

        while (IsCheckPlayer() || !GameManager.IsPlayerDead())
        {
            ShamanBullet sb = Instantiate(bullet, transform.position, Quaternion.identity);
            sb.Fire();
            yield return new WaitForSeconds(3);
        }
        isCheck = false;
    }

    public bool IsCheckPlayer()
    {
        return Vector2.Distance(transform.position, playerTrm.position) <= 5;
    }
}
