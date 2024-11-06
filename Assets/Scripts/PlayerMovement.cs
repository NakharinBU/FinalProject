using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    public float acceleration;
    public float groundSpeed;
    public float jumpSpeed;

    [Range(0,1f)]
    public float groundDecay;
    public bool grounded;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    float xInput;
    float yInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
    }

    public void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
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
            float newSpeed = Mathf.Clamp(rb2d.velocity.x + increment, -groundSpeed , groundSpeed);
            rb2d.velocity = new Vector2(xInput * groundSpeed, rb2d.velocity.y);

            FaceInput();
        }
    }

    public void HandleJump() 
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }


    public void ApplyFriction() 
    {
        if (grounded && xInput == 0 && rb2d.velocity.y <= 0)
        {
            rb2d.velocity *= groundDecay;
        }
    }

    public void FaceInput() 
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

}
