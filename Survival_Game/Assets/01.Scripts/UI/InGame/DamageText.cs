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

        float red = Mathf.Clamp01(damage / 50);
        float green = 1 - red;
        damageText.color = new Color(red, green, green);

        transform.DOMoveY(pos.y + 0.5f, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }

}
