using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 defaultLScale;
    private Vector3 defaultPos;
    private enum WalkDirection
    {
        Left, Right
    };
    private WalkDirection Direction;

    [SerializeField]
    private float walkrange = 20;
    [SerializeField]
    private float velocity = 6;

    private float _diff;
    private Vector2 _movedistance;

    // Start is called before the first frame update
    void Start()
    {
        defaultLScale = transform.localScale;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ƒ|ƒbƒvêŠ‚©‚ç¶‚Éwalkrange‚Ü‚Å‚Ì”ÍˆÍ‚Åœpœj‚·‚é
        _diff = (defaultPos.x - transform.position.x);
        Debug.Log(_diff);
        switch (_diff)
        {
            case float f when 0 >= f:
                Direction = WalkDirection.Left;
                Debug.Log("Left");
                break;
            case float f when f > walkrange:
                Direction = WalkDirection.Right;
                Debug.Log("Right");
                break;
            default:
                Debug.Log("mid");
                break;
        }
        SetDirection(Direction);
        Move(Direction);
    }

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
}
