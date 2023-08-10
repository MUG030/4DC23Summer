using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public sbyte _direction;
    private byte StopFlames;
    private bool Attacking = false;
    private SpriteRenderer image;
    private GameObject sord;
    private Animator anim;
    public Sprite sprite1, sprite2;

    void Start()
    {
        sord = transform.GetChild(0).gameObject;
        image = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        if (StopFlames == 0 && Input.GetKeyDown(KeyCode.W))
        {
            anim.enabled = false;
            
            image.sprite = sprite1;
            sord.SetActive(true);
            sord.transform.localPosition = new Vector2(-1.2f,0.5f);  
            Attacking = true;
            StopFlames = 60;
        }

        if(Attacking)
        {
            Attack(sord);
        }
    }

    void Attack(GameObject s)
    {
        s.transform.Translate(0,-0.025f,0);
        StopFlames -= 1;

        if(StopFlames == 45)
        {
            image.sprite = sprite2;
        }

        if(StopFlames == 0)
        {
            s.transform.localPosition = Vector2.zero;
            Attacking = false;
            sord.SetActive(false);
            anim.enabled = true;
        }
    }
}
