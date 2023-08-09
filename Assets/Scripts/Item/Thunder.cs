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
                Debug.Log(pull);
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
        isPlayer = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
    }
}
