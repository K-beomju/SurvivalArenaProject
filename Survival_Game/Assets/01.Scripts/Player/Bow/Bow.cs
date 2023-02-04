using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Arrow arrow;
    private BowRotation bowRot;

    private void Awake() 
    {
        bowRot = GetComponentInParent<BowRotation>();
    }

    public void SpawnArrow()
    {
        arrow = PoolManager.GetArrowObject();
        arrow.transform.position = bowRot.hand.position;
        arrow.transform.rotation = bowRot.hand.rotation;
        arrow.Fire();

        SoundManager.Instance.PlayFXSound("ArrowFx");

    }
}
