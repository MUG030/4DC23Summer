using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public bool isPlayer = false;
    private byte pull = 0;
    private bool move = false;
    private int flame = 0;

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
                Debug.Log(pull);
                pull = 0;
            }
        }

        if(pull > 200)
        {
            move = true;
        }

        if(move)
        {
           if(pull < 10)
            {

            }
        }

    }

    public void OnTriggerStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("test");
            isPlayer = true;
        }
    }
    public void OnTriggerExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        { 
            isPlayer = false;
        }
    }
}
