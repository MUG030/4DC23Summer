using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = string.Format("{0:0.00}s", TimeScore.ResultTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
