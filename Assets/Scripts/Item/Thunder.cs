using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public bool isPlayer = false;
    private byte pull = 0;

    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.P))
            {
                pull += 1;
            }
            else
            {
                pull = 0;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(pull);
        isPlayer = true;
    }
    public void OnColliderExit2D(Collider2D collision)
    {
        isPlayer = false;
    }
}
