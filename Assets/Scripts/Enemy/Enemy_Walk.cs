using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : MonoBehaviour, IDamageable
{
    private SpriteRenderer enemySprite;
    [SerializeField]
    private Sprite enemyDefeated;

    private enum WalkDirection
    {
        Left, Right
    };
    private enum EnemyStatus
    {
        Alive, Damaged, Dying, Dead
    };
    private WalkDirection Direction;
    private EnemyStatus Status;

    private Vector3 defaultLScale;
    private Vector3 defaultPos;

    private int health;
    [SerializeField, Space(10)]
    private float walkrange = 10;
    [SerializeField]
    private float velocity = 4;
    [SerializeField, Space(10)]
    private float fadetime = 1.2f;


    private float _diff;
    private Vector2 _movedistance;
    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        defaultLScale = transform.localScale;
        defaultPos = transform.position;
        health = 1;
        Status = EnemyStatus.Alive;
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ポップ場所から左にwalkrangeまでの範囲で徘徊する
        #region
        _diff = (defaultPos.x - transform.position.x);
        switch (_diff)
        {
            case float f when 0 >= f:
                Direction = WalkDirection.Left;
                break;
            case float f when f > walkrange:
                Direction = WalkDirection.Right;
                break;
            default:
                break;
        }
        SetDirection(Direction);
        Move(Direction);
        #endregion

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
                    enemySprite.sprite = enemyDefeated;
                }
                else
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

    }
    //タグ名「PlayerWeapon」のオブジェクトと接触したらダメージをうける
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "PlayerWeapon")
        {
            Status = EnemyStatus.Damaged;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
        {
            Status = EnemyStatus.Damaged;
        }
    }
    //徘徊関連
    #region
    private void SetDirection(WalkDirection direction)
    {
        transform.localScale = direction switch
        {
            WalkDirection.Left => new Vector2(defaultLScale.x, defaultLScale.y),
            WalkDirection.Right => new Vector2(defaultLScale.x * -1, defaultLScale.y)
        };
    }
    private void Move(WalkDirection direction)
    {
        _movedistance = direction switch
        {
            WalkDirection.Left => new Vector2(velocity * Time.deltaTime * -1, 0),
            WalkDirection.Right => new Vector2(velocity * Time.deltaTime, 0)
        };

        transform.Translate(_movedistance);
    }
    #endregion
    public int AddDamage()
    {
         Debug.Log("敵に触れた");
         return 1;
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        health++;
        Status = EnemyStatus.Damaged;
    }
}
