using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public sbyte _direction;
    private byte Frame;
    private bool Attacking = false;
    private SpriteRenderer Image;
    private GameObject Sord;
    private Animator Anim;
    public Sprite Sprite1, Sprite2;

    void Start()
    {
        Sord = transform.GetChild(0).gameObject;
        Image = gameObject.GetComponent<SpriteRenderer>();
        Anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        if (Frame == 0 && Input.GetKeyDown(KeyCode.W))
        {
            Anim.enabled = false;
            
            Image.sprite = Sprite1;
            Sord.SetActive(true);
            Sord.transform.localPosition = new Vector2(-1.2f,0.5f);  
            Attacking = true;
            Frame = 60;
        }

        if(Attacking)
        {
            Attack(Sord);
        }
    }

    void Attack(GameObject s)
    {
        s.transform.Translate(0,-0.025f,0);
        Frame -= 1;

        if(Frame == 18)
        {
            Image.sprite = Sprite2;
        }

        if(Frame == 0)
        {
            s.transform.localPosition = Vector2.zero;
            Attacking = false;
            Sord.SetActive(false);
            Anim.enabled = true;
        }
    }
}
