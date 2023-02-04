using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    private Slider levelSlider;

    private void Awake()
    {
        levelSlider = GetComponent<Slider>();
    }

    public void AddGuage(float exp)
    {

        if(levelSlider.value + exp >= levelSlider.maxValue)
        {
            Debug.Log("Level Up!");
            SkillManager.Instance.SpawnItem();
            levelSlider.value = levelSlider.value + exp - levelSlider.maxValue;

            levelSlider.maxValue *= 1.8f;
        }
        else
        {
            levelSlider.value = levelSlider.value + exp;
        }
    }
}
