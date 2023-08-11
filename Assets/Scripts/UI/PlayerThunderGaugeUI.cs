using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThunderGaugeUI : MonoBehaviour
{
    [SerializeField] private Slider gaugeSlider;

    public void SetValue(int currentThunderCount, int requireThunderCount)
    {
        gaugeSlider.value = Mathf.Clamp((float)currentThunderCount / requireThunderCount, 0f, 1f);
    }
}
