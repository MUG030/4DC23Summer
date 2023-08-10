using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private bool isPlayer = false;
    private bool Get = false;
    private byte Pull = 0;

    private GameObject Player;

    private Animator Anim;
    public SpriteRenderer Image;
    //public Sprite Sprite1, Sprite2;

    public int ThunderCount;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Image = Player.GetComponent<SpriteRenderer>();
        Anim = Player.GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Anim.enabled = false;
                //Image.sprite = Sprite1;
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
                Get = true;
                Pull = 0;
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
