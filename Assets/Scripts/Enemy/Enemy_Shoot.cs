using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public static GameObject Player;
    [SerializeField]
    private GameObject player;
    [Space(10)]
    private SpriteRenderer enemySprite;
    [SerializeField]
    private Sprite WaitPose;
    [SerializeField]
    private Sprite ShotPose;

    [SerializeField]
    private GameObject bulletPrefab;
    private GameObject bullet;
    private Transform playerTra;
    private Vector2 _posdiff;
    private float _base;
    private float _side;
    private float shotangle_rad;
    [SerializeField]
    private float shotvelocity = 2.0f;
    [SerializeField]
    private float shotinterval = 4.0f;
    private float shotposetime = 0.5f;
    private Vector2 shotpower;

    private enum EnemyStatus
    {
        Alive, Damaged, Dying, Dead
    };
    private EnemyStatus Status;
    private int health;
    [SerializeField]
    private float fadetime = 1.2f;

    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        Status = EnemyStatus.Alive;
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        Player = player;
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
    }

    private void OnBecameVisible()
    {
        //���@�_���J�n
        StartCoroutine("ShotBullet");
        Debug.Log("startct");
    }
    private void OnBecameInvisible()
    {
        //���@�_����~
        StopCoroutine("ShotBullet");
        Debug.Log("stopct");

    }
    //�^�O���uPlayerWeapon�v�̃I�u�W�F�N�g�ƐڐG������_���[�W��������
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
            //Player�ʒu�擾
            playerTra = Player.transform;
            //�p�x����
            _posdiff = playerTra.position - gameObject.transform.position;
            _base = _posdiff.x;
            _side = _posdiff.y;
            shotangle_rad = Mathf.Atan(_side / _base);
            //����
            bullet = Instantiate(bulletPrefab, gameObject.transform);
            //�ˑ�����
            shotpower = new Vector2(
                shotvelocity * Mathf.Cos(shotangle_rad),
                shotvelocity * Mathf.Sin(shotangle_rad)
            );
            shotpower *= new Vector2(Mathf.Sign(_posdiff.x), Mathf.Sign(_posdiff.y));
            //�ˏo
            bullet.GetComponent<Enemy_Bullet>().SetVelocity(shotpower);

            enemySprite.sprite = ShotPose;
            yield return new WaitForSeconds(shotposetime);
            enemySprite.sprite = WaitPose;
            //�C���^�[�o��
            yield return new WaitForSeconds(shotinterval-shotposetime);
        }
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        health++;
        Status = EnemyStatus.Damaged;
    }

}
