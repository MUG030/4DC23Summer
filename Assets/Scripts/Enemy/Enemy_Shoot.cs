using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    private SpriteRenderer enemySprite;

    private enum EnemyStatus
    {
        Alive, Damaged, Dying, Dead
    };
    private EnemyStatus Status;
    private int health;
    private float fadetime = 1.2f;

    private bool isVisible;

    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        Status = EnemyStatus.Alive;
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //��_���A�t�F�[�h�A����
        switch (Status)
        {
            case EnemyStatus.Alive:
                break;
            case EnemyStatus.Damaged:
                health -= 1;
                if (health <= 0)
                {
                    //�R���C�_�[����
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Status = EnemyStatus.Dying;
                } else
                    Status = EnemyStatus.Alive;
                break;
            case EnemyStatus.Dying:
                //�t�F�[�h�̕����� = �t�F�[�h����/fix�̊Ԋu
                //1�񂠂���Ƀt�F�[�h�x = 1s / ������
                _color = enemySprite.color;
                _color.a -= Time.fixedDeltaTime / fadetime;
                enemySprite.color = _color;
                if (enemySprite.color.a <= 0)
                    Status = EnemyStatus.Dead;
                break;
            case EnemyStatus.Dead:
                Destroy(gameObject);
                break;
        }
        
        if(isVisible)
        {
            //Player�ʒu�擾
            //�p�x����
            //�ˏo
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
        //���@�_���J�n
    }
    private void OnBecameInvisible()
    {
        isVisible = false;
        //���@�_����~
    }
}
