using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageText : MonoBehaviour
{
    private TextMeshPro damageText;

    private void Awake() 
    {
        damageText = GetComponent<TextMeshPro>();
    }

    public void ShowDamageText(float damage, Vector3 pos)
    {
        transform.position = pos;
        damageText.text = damage.ToString();
        transform.DOMoveY(pos.y + 0.5f, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }

}
