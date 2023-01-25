using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BowRotation : MonoBehaviour
{
    [SerializeField] public Transform hand;
    private Vector3 enemyPos;

    private float angle;

    public void AngleToWardsEnemy(bool checkEnemy , GameObject enemy)
    {
        if (checkEnemy)
        {
            enemyPos = enemy.transform.position;
            angle = Mathf.Atan2(enemyPos.y - transform.position.y, enemyPos.x - transform.position.x) * Mathf.Rad2Deg;
            hand.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
        else
        {
            hand.rotation = Quaternion.Euler(0, 0, 40);
        }
    }

}
