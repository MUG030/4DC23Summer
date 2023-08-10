using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private bool isPlayer = false;
    private byte Pull = 0;
    private GameObject Player;
    public int ThunderCount;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Pull = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("pulling");
                Pull += 1;
            }

            if (Pull > 180)
            {
                Debug.Log("pulled");
                Player.GetComponent<PlayerGetThunder>().Get = true;
                this.gameObject.SetActive(false);
            }
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("in");
            isPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("out");
            isPlayer = false;
        }
    }
}
