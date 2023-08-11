using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SCTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void SCMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SCClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void SCCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
