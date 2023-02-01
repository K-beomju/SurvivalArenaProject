using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Slider hpSlider;

    private void Awake() 
    {
        hpSlider = GetComponent<Slider>();    
    }

    public void SetFill(float current, float max)
    {
        if(hpSlider != null)
        hpSlider.value = Mathf.Clamp(current / max, 0, 1);
    }

    private void FixedUpdate()    
    {
        transform.position = Camera.main.WorldToScreenPoint(GameManager.Instance.hpTrm.position);
    }

    
}
