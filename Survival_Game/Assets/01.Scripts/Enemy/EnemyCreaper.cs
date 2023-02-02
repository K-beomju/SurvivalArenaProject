using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCreaper : Enemy
{
    private bool isCheck = false;
    public GameObject creaperArea;

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
                StartCoroutine(FireCreaper());
                isCheck = true;
            }
        }
    }

    public IEnumerator FireCreaper()
    {
        while (IsCheckPlayer() || !GameManager.IsPlayerDead())
        {
            for (int i = 0; i < 5; i++)
            {
                enemyHealth.sr.color = Color.red;
                yield return new WaitForSeconds(0.2f);
                enemyHealth.sr.color = Color.white;
                yield return new WaitForSeconds(0.2f);
                enemyHealth.sr.color = Color.red;
            }
            
            enemyHealth.sr.color = Color.white;
            creaperArea.SetActive(true);
            creaperArea.transform.localScale = Vector3.zero;
            creaperArea.transform.DOScale(new Vector2(5, 5), 3).OnComplete(() =>
            {
                //TODO
                if (IsCheckPlayer(2.5f))
                {
                    GameManager.Instance.ph.CheckHitDelay();
                    GameManager.Instance.ph.OnDamage(3);
                }
                creaperArea.SetActive(false);
            });

            yield break;
        }
        isCheck = false;
    }

}
