using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public sbyte _direction;
    public byte StopFlames;
    private bool Attacking = false;

    void Update()
    {
        Transform tf = this.transform;

        if (StopFlames == 0 && Input.GetKeyDown(KeyCode.W))
        {
            tf.localPosition = new Vector2(1.2f,0.5f);  
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
