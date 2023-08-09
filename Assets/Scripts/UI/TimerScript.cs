using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float seconds;
    private Stopwatch stopWatch;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        stopWatch = new Stopwatch();
    }

    void Update()
    {
        TakeTime();
    }
    //　時間計測メソッド
    void TakeTime()
    {
        seconds += Time.deltaTime;
        var timeSpan = new TimeSpan(0, 0, (int)seconds);
        timerText.SetText("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
    //　経過時間を返す
    public int GetSeconds()
    {
        return (int)seconds;
    }
}
