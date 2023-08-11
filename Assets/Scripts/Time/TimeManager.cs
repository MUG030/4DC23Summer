using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float currentTime = 0f;

    private bool timerStop = false;

    private void Start()
    {
        // èâä˙ï\é¶
        UpdateTimerText();
        TimeScore.ResultTime = 0f;
    }

    private void Update()
    {
        if(timerStop == false)
        {
            // 1ïbÇ≤Ç∆Ç…éûä‘ÇçXêV
            currentTime += Time.deltaTime;
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);

        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", minutes, seconds, milliseconds);    }

    public void StopTimer()
    {
        timerStop = true;
        TimeScore.ResultTime = currentTime;
    }
}
