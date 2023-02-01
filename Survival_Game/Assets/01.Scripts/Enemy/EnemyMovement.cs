using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    private void OnEnable()
    {
        anim.enabled = true;
        StartCoroutine(base.TrackingPlayerCo());
    }


}
