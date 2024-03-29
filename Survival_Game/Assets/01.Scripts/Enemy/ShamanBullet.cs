using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanBullet : MonoBehaviour
{
    [SerializeField] private float power;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector3 dir)
    {
        rb.velocity = dir * -power;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ph.CheckHitDelay();
            GameManager.Instance.ph.OnDamage(1);
        }
    }
}
