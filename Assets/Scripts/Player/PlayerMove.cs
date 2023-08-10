using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMove : MonoBehaviour
{
    PlayerHP playerHP;

    private Vector2 _startScale;
    Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isShiftPressed = false;
    private bool isSprinting = false;
    private bool isDamage = false;

    [SerializeField] private float _speedForce = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    float springForce = 1.0f;

    [SerializeField] private float _groundCheckDistance = 0.3f;
    private int groundLayer = 1 << 6;

    private float _horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHP = GetComponent<PlayerHP>();
        animator = GetComponent<Animator>();
        _startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamage) return;

        animator.SetFloat("speed", Mathf.Abs(_horizontalInput));
        animator.SetBool("isGround", isGrounded);
        animator.SetBool("IsJump", true);

        Debug.Log(rb.velocity.y);
        if (rb.velocity.y > 0.4f)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", true);
        }

        if (isGrounded)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", false);
            animator.SetBool("IsJumpWing", false);
            animator.SetBool("IsFallWing", false);
        }
        _horizontalInput = Input.GetAxis("Horizontal");

        if (_horizontalInput > 0.0f)
        {
            transform.localScale = new Vector2(_startScale.x, _startScale.y);
        }
        else if (_horizontalInput < 0.0f)
        {
            transform.localScale = new Vector2(_startScale.x * -1, _startScale.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if (isShiftPressed)
        {
            if (rb.velocity.y > 0.4f)
            {
                animator.SetBool("IsJumpWing", true);
                animator.SetBool("IsJump", false);
            }
            else
            {
                animator.SetBool("IsFall", false);
                animator.SetBool("IsJumpWing", false);
                animator.SetBool("IsFallWing", true);
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();

        if (isGrounded || _horizontalInput != 0)
        {
            rb.velocity = new Vector2(_horizontalInput * _speedForce, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private bool CheckGround()
    {
        Vector2 positionLeft = (Vector2)transform.position - Vector2.left * 0.35f - Vector2.up;
        Vector2 positionRight = (Vector2)transform.position - Vector2.right * 0.5f - Vector2.up;
        Vector2 direction = Vector2.down;
        float distance = _groundCheckDistance;

        RaycastHit2D hitLeft = Physics2D.Raycast(positionLeft, direction, distance, groundLayer);
        Debug.DrawRay(positionLeft, direction * distance, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(positionRight, direction, distance, groundLayer);
        Debug.DrawRay(positionRight, direction * distance, Color.red);
        return hitLeft.collider != null || hitRight.collider != null;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var target = col.GetComponent<IDamageable>();
        var jumpTarget = col.GetComponent<IGain>();
        if (target != null)
        {
            if (isDamage) return;

            int DamageNum = target.AddDamage();
            playerHP.SetLifeGauge2(DamageNum);
        } else if (jumpTarget!= null)
        {
            springForce = jumpTarget.JumpForce();
            rb.AddForce(Vector2.up * springForce, ForceMode2D.Impulse);
        }
    }
}
