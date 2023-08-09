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
        // Shiftキーが押されているかを判定
        isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // 重力のスケールを設定
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
