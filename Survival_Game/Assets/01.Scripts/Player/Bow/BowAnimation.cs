using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimation : MonoBehaviour, IBowAnimation
{
    private Animator anim;
    private readonly int hashAttack = Animator.StringToHash("isAttack");

    private void Awake() 
    {
        anim = GetComponent<Animator>();    
    }

    public void BowAttackAnim(bool isActive)
    {
        anim.SetBool(hashAttack, isActive);
    }
}
