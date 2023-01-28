using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HitEffect : MonoBehaviour
{
    private Image image;

    private void Awake() 
    {
        image = GetComponent<Image>();    
    }

    [ContextMenu("HitScreen")]
    public void HitScreen()
    {
        image.DOColor(new Color32(255,78,78,50), 0.2f).OnComplete(() => image.DOColor(new Color32(255,78,78,0),0.2f));
    }
}
