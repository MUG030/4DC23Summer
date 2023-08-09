using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isShiftPressed = false;
    private float originalGravityScale;

    [SerializeField] private float halfGravityScale = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        // Shift�L�[��������Ă��邩�𔻒�
        isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // �d�͂̃X�P�[����ݒ�
        if (isShiftPressed)
        {
            rb.gravityScale = halfGravityScale;
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }
    }
}
