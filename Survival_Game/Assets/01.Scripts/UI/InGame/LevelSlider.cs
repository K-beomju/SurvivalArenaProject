using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    private Slider levelSlider;
    private int level = 0;

    private void Awake()
    {
        levelSlider = GetComponent<Slider>();
    }

    private void Start()
    {

    }

    public void AddGuage(float exp)
    {
        //levelSlider.value = levelSlider.value + exp >= levelSlider.maxValue ? levelSlider.value + exp - levelSlider.maxValue : levelSlider.value + exp;

        if(levelSlider.value + exp >= levelSlider.maxValue)
        {
            Debug.Log("Level Up!");
            levelSlider.value = levelSlider.value + exp - levelSlider.maxValue;

            levelSlider.maxValue *= 1.8f;
        }
        else
        {
            levelSlider.value = levelSlider.value + exp;
        }
    }
}
