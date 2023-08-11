using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetThunder : MonoBehaviour
{
    public bool Get = false;
    public byte Count = 0;

    public Animator playerAnim;

    void Update()
    {
        if(Get)
        {
            Count += 1;
            Debug.Log(Count);
            Get = false;
            EndPulling();
        }
    }

    public void StartPulling()
    {
        playerAnim.SetBool("IsPulling", true);
    }

    public void EndPulling()
    {
        playerAnim.SetBool("IsPulling", false);
    }
}
