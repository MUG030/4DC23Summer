using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public sbyte _direction;
    public byte StopFlames;
    private bool Attacking = false;

    void Start()
    {   
    }

    void Update()
    {
        /*
        if(Input.GetAxis("Horizontal") != 0.0f)
        {
            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                _direction = 1;
            }
            else
            {
                _direction = -1;
            }
        }*/

            Debug.Log(_direction);

        Transform tf = this.transform;

        if (StopFlames == 0 && Input.GetKeyDown(KeyCode.W))
        {
            tf.localPosition = new Vector2(1,0.5f);  
            Attacking = true;
            StopFlames = 40;
        }

        if(Attacking)
        {
            Attack(tf);
        }
    }

    void Attack(Transform tf)
    {
        tf.Translate(0,-0.05f,0);
        StopFlames -= 1;

        if(StopFlames == 0)
        {
            tf.localPosition = Vector2.zero;
            Attacking = false;
        }

    }


}