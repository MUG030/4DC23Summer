using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialGaugeUI : MonoBehaviour
{
    [Header("Sliderの参照")]
    [SerializeField] private Slider sliderUI;

    [Header("必殺技ゲージの最大値")]
    [SerializeField] private int maxGaugeValue = 100;

    [Header("ゲージの初期値")]
    [SerializeField] private int initialGaugeValue = 0;

    void Start()
    {
        sliderUI.maxValue = maxGaugeValue;
        sliderUI.value = initialGaugeValue;
    }

    /// <summary>
    /// 必殺技ゲージの値を設定します。
    /// </summary>
    /// <param name="gaugeValue">設定したいゲージの値</param>
    public void SetGaugeValue(int gaugeValue)
    {
        sliderUI.value = gaugeValue;
    }
}
