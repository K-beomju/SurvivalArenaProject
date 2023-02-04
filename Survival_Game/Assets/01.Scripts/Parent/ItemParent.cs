using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemParent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Eat();
        }    
    }

    protected abstract void Eat();
}
