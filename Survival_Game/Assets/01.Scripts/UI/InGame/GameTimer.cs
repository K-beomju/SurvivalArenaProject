using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text timerText;
    private float startTime;
    private float t;

    void Awake()
    {
        timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    void Update()
    {
        if (!GameManager.IsPlayerDead())
        {
            t = Time.time - startTime;
            timerText.text = string.Format("{0:00}:{1:00}", (int)t / 60, (int)t % 60);
        }
    }
}
