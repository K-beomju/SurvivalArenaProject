using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleItem : ItemParent
{
    protected override void Eat()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.ph.RestoreHealth(2);
    }
    
}
