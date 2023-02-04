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
        if (GameManager.IsPlayerDead()) yield break;

        if(this.gameObject.activeSelf)
        StraightShot();
        yield return new WaitForSeconds(5);

        isCheck = false;
    }

    public void StraightShot()
    {
        ShamanBullet sb = Instantiate(bullet, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(transform.position.y - GameManager.playerTrm().position.y, transform.position.x - GameManager.playerTrm().position.x) * Mathf.Rad2Deg;
        sb.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        var dir = (transform.position - GameManager.playerTrm().position).normalized;
        sb.Fire(dir);

    }
}
