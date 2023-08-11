using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindows : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
