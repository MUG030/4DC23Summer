using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;

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
    private Color enemyColor;

    private int health;
    [SerializeField]
    private float walkrange = 10;
    [SerializeField]
    private float velocity = 6;
    [SerializeField]
    private float fadetime = 1.2f;
    private float _timecount;
    private float adjustedtime;


    private float _diff;
    private Vector2 _movedistance;

    // Start is called before the first frame update
    void Start()
    {
        defaultLScale = transform.localScale;
        defaultPos = transform.position;
        health = 1;
        Status = EnemyStatus.Alive;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�|�b�v�ꏊ���獶��walkrange�܂ł͈̔͂Ŝp�j����
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

        switch (Status)
        {
            case EnemyStatus.Alive:
                break;
            case EnemyStatus.Damaged:
                health -= 1;
                Debug.Log("dam");
                if (health <= 0)
                {
                    Debug.Log("h0");
                    //�R���C�_�[����
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Status = EnemyStatus.Dying;
                    _timecount = 0;
                }
                break;
            case EnemyStatus.Dying:
                //�t�F�[�h�̕����� = �t�F�[�h����/fix�̊Ԋu
                //1�񂠂���Ƀt�F�[�h�x = 1s / ������
                //enemyColor.a -= Time.fixedDeltaTime / fadetime;
                Debug.Log("dying");
                _timecount += Time.fixedDeltaTime;
                adjustedtime = _timecount / fadetime;
                enemyColor.a = (adjustedtime - 1)*(adjustedtime - 1)*(2*adjustedtime + 1);
                if (enemyColor.a >= 1)
                    Status = EnemyStatus.Dead;
                break;
            case EnemyStatus.Dead:
                Destroy(gameObject);
                break;
        }

    }
    //�^�O���uPlayerWeapon�v�̃I�u�W�F�N�g�ƐڐG������_���[�W��������
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "PlayerWeapon")
        {
            Status = EnemyStatus.Damaged;
        }
    }
    //�p�j�֘A
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
         Debug.Log("�G�ɐG�ꂽ");
         return 1;
    }

}
