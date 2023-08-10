using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour, IDamageable
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hitSound;
    private float soundLength = 2.0f;
    private enum EnemyStatus
    {
        none, Alive, Damaged, Dying, Dead
    };
    private EnemyStatus Status;

    private int health;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        Status = EnemyStatus.Alive;
        audioSource = gameObject.GetComponent<AudioSource>();
   }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(velocity * Time.deltaTime);
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
                    Status = EnemyStatus.Dead;
                } else
                    Status = EnemyStatus.Alive;
                break;
            /*
            case EnemyStatus.Dying:
                
                //フェードの分割数 = フェード時間/fixの間隔
                //1回あたりにフェード度 = 1s / 分割数
                _color = enemySprite.color;
                _color.a -= Time.fixedDeltaTime / fadetime;
                enemySprite.color = _color;
                if (enemySprite.color.a <= 0)
                    Status = EnemyStatus.Dead;
                break;
            */
            case EnemyStatus.Dead:
                StartCoroutine("Hit");
                Status = EnemyStatus.none;
                break;
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this);
    }

    public int AddDamage()
    {
        Debug.Log("胞子に触れた");
        int damage = (health > 0) ? 1 : 0;
        health--;
        Status = EnemyStatus.Damaged;
        return damage;
    }
    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        health++;
        Status = EnemyStatus.Damaged;
    }

    private IEnumerator Hit()
    {
        SetVelocity(Vector2.zero);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        audioSource.PlayOneShot(hitSound);
        yield return new WaitForSeconds(soundLength);
        Debug.Log("delayed");
        Destroy(gameObject);
    }
}
