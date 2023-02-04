using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float power;

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Vector3 dir;


    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    public void Fire()
    {
        dir = transform.up;
        rb.velocity = dir * -power;
    }

    private void OnBecameInvisible() 
    {
        gameObject.SetActive(false);
        tr.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            eh.OnDamage(12);
            gameObject.SetActive(false);
        }
    }

  

  
}
