using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetThunder : MonoBehaviour
{
 
    byte pulling = 0;
    bool isThunder = false;

    void Update()
    {

        if (isThunder)
        {
            if (Input.GetKey(KeyCode.P))
            {
                pulling += 1;
            }
            else
            {
                pulling = 0;
            }

            if (pulling > 250)
            {
                
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "Thunder")
        {
            Debug.Log("test");
            isThunder = true;
        }
        else
        {
            isThunder = false;
        }
    }
}
