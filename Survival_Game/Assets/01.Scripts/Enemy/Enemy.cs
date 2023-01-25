using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health { get; set; }
    public EnemyMovement Movement { get; set; }

    private void Awake() 
    {
        Health = GetComponent<EnemyHealth>();
        Movement = GetComponent<EnemyMovement>();
    }

    
}
