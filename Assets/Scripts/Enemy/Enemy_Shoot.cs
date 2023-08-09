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
        //被ダメ、フェード、消滅
        switch (Status)
        {
            case EnemyStatus.Alive:
                break;
            case EnemyStatus.Damaged:
                health -= 1;
                if (health <= 0)
                {
                    //コライダー消す
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Status = EnemyStatus.Dying;
                } else
                    Status = EnemyStatus.Alive;
                break;
            case EnemyStatus.Dying:
                //フェードの分割数 = フェード時間/fixの間隔
                //1回あたりにフェード度 = 1s / 分割数
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
            //Player位置取得
            //角度決定
            //射出
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
        //自機狙い開始
    }
    private void OnBecameInvisible()
    {
        isVisible = false;
        //自機狙い停止
    }
}
