using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth enemyHealth { get; set; }
    public EnemyMovement enemyMovement { get; set; }
    public Animator anim { get; set; }

    protected virtual void Awake() 
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
    }

    
}
