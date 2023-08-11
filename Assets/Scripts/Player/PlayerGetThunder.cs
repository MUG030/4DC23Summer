using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetThunder : MonoBehaviour
{
    public bool Get = false;
    public byte Count = 0;

    void Update()
    {
        if(Get)
        {
            Count += 1;
            Debug.Log(Count);
            Get = false;
        }
    }
}
