using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    //三日目夜：よく見たら1枚のスクリプトに書く量じゃないwww
    [SerializeField]
    private GameObject player;
    private SpriteRenderer enemySprite;
    [SerializeField,Space(10)]
    private Sprite WaitPose;
    [SerializeField]
    private Sprite ShotPose;

    [SerializeField,Space(10)]
    private GameObject bulletPrefab;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip shotSound;
    private GameObject shotMuzzle;
    private GameObject bullet;
    private Transform playerTra;
    private Vector2 _posdiff;
    private float _base;
    private float _side;
    private float shotangle_rad;
    [SerializeField, Space(5)]
    private float shotvelocity = 2.0f;
    [SerializeField]
    private float shotinterval = 4.0f;
    [SerializeField]
    private float shotposetime = 1.1f;
    private float shotdelay = 0.2f;
    private Vector2 shotpower;

    private enum EnemyStatus
    {
        Alive, Damaged, Dying, Dead
    };
    private EnemyStatus Status;
    private int health;
    [SerializeField,Space(10)]
    private float fadetime = 1.2f;

    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        Status = EnemyStatus.Alive;
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        shotMuzzle = gameObject.transform.Find("ShotMuzzle").gameObject;
        audioSource = gameObject.GetComponent<AudioSource>();
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
    }

    private void OnBecameVisible()
    {
        //自機狙い開始
        StartCoroutine("ShotBullet");
    }
    private void OnBecameInvisible()
    {
        //自機狙い停止
        StopCoroutine("ShotBullet");

    }
    //タグ名「PlayerWeapon」のオブジェクトと接触したらダメージをうける
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "PlayerWeapon")
        {
            Status = EnemyStatus.Damaged;
        }
    }

    private IEnumerator ShotBullet()
    {
        while (true)
        {
            //Player位置取得
            playerTra = player.transform;
            //角度決定
            _posdiff = playerTra.position - gameObject.transform.position;
            _base = _posdiff.x;
            _side = _posdiff.y;
            shotangle_rad = Mathf.Atan(_side / _base);

            audioSource.PlayOneShot(shotSound);
            enemySprite.sprite = ShotPose;
            yield return new WaitForSeconds(shotdelay);

            //生成
            bullet = Instantiate(bulletPrefab, gameObject.transform);
            bullet.transform.position = shotMuzzle.transform.position;

            //射速決定
            shotpower = new Vector2(
                shotvelocity * Mathf.Cos(shotangle_rad),
                shotvelocity * Mathf.Sin(shotangle_rad)
            );
            shotpower *= new Vector2(Mathf.Sign(_posdiff.x), Mathf.Sign(_posdiff.y));

            //射出(音付き)
            bullet.GetComponent<Enemy_Bullet>().SetVelocity(shotpower);
            yield return new WaitForSeconds(shotposetime);
            enemySprite.sprite = WaitPose;

            //インターバル
            yield return new WaitForSeconds(shotinterval-shotposetime-shotdelay);
        }
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        health++;
        Status = EnemyStatus.Damaged;
    }
}
