using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BowRotation : MonoBehaviour
{
    [SerializeField] public Transform hand;

    private PlayerAttack playerAk;
    private Vector3 enemyPos;

    private float angle;

    private void Awake()
    {
        playerAk = GetComponent<PlayerAttack>();
    }

    private void AngleToWardsEnemy()
    {
        enemyPos = playerAk.enemy.transform.position;
        angle = Mathf.Atan2(enemyPos.y - transform.position.y, enemyPos.x - transform.position.x) * Mathf.Rad2Deg;
        hand.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    private void Update()
    {
        if (playerAk.enemy != null && playerAk.enemy.activeSelf && !GameManager.IsPlayerDead())
            AngleToWardsEnemy();
        else
            hand.rotation = Quaternion.Euler(0,0,40);

    }


}
