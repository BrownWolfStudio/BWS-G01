using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool facingRight = true;

    Animator animator;

    public float Speed = 10f;
    public float JumpVelocity = 8f;
    float moveInput;

    Rigidbody2D rb;

    bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    int ExtraJumpsValue;
    public int ExtraJumps;
    public Transform Face;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        ExtraJumpsValue = ExtraJumps;
    }

    void Update()
    {
        if (isGrounded) ExtraJumps = ExtraJumpsValue;

        if (Input.GetButtonDown("Jump") && ExtraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpVelocity;
            ExtraJumps--;
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetButtonDown("Jump") && ExtraJumps > 0 && isGrounded)
        {
            rb.velocity = Vector2.up * JumpVelocity;
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, WhatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
