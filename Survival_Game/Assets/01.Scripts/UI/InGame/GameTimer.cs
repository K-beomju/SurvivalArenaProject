using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text timerText;
    private float startTime;
    private float t;
    private string minutes;
    private string seconds;

    void Start()
    {
        timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    void Update()
    {
        t = Time.time - startTime;
        minutes = ((int)t / 60).ToString("00");
        seconds = ((int)t % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;
    }
}
