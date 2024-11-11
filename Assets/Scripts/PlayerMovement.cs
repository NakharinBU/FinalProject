using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator animator;

    public float acceleration;
    public float groundSpeed;
    public float jumpSpeed;

    [Range(0, 1f)]
    public float groundDecay;
    public bool isGrounded;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    float xInput;
    float yInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();
        MoveWithInput();
        HandleJump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        animator.SetFloat("xVelocity", Mathf.Abs(rb2d.velocity.x));
        animator.SetFloat("yVelocity", jumpSpeed);
    }

    public void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    public void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    public void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
            {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(rb2d.velocity.x + increment, -groundSpeed, groundSpeed);
            rb2d.velocity = new Vector2(newSpeed, rb2d.velocity.y);
            FaceInput();
        }
        else
        {
            // หยุดการเคลื่อนที่ในแนวนอนเมื่อไม่ได้กดปุ่ม
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    public void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", isGrounded);

        }
    }

    public void ApplyFriction()
    {
        if (isGrounded && xInput == 0 && rb2d.velocity.y <= 0)
        {
            rb2d.velocity *= groundDecay;
        }
    }

    public void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
