using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private bool isPlayer = false;
    private bool Move = false;
    private byte Pull = 0;
    private byte Frame = 0;
    private Animator Anim;
    public SpriteRenderer Image;
    public Sprite Sprite1, Sprite2;

    void Start()
    {
        Anim = Image.GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Anim.enabled = false;
                Image.sprite = Sprite1;
                Debug.Log("test2");
                Pull = 0;
            }

            if (Input.GetKey(KeyCode.P))
            {
               Pull += 1;
            }

            if (Pull > 180)
            {
                Debug.Log("pulled");
                Move = true;
                Pull = 0;
                Frame = 240;
            }
        }

        if(Move)
        {
           if(Pull < 10)
            {

            }
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        { 
            isPlayer = false;
        }
    }
}
