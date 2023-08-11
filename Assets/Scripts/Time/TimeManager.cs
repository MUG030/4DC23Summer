using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float currentTime = 0f;

    private void Start()
    {
        // ‰Šú•\¦
        UpdateTimerText();
    }

    private void Update()
    {
        // 1•b‚²‚Æ‚ÉŠÔ‚ğXV
        currentTime += Time.deltaTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);

        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", minutes, seconds, milliseconds);    }
}
