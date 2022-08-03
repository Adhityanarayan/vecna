using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFacingRight;
    private bool isGrounded;
    private bool isBoxes;

    public Joystick joystick;

    public float moveSpeed = 8f;
    public float jumpForce = 16f;
    public float horizontal { get; private set; }
    public Transform groundCheck;
    public float gndCheckRadius = 0.3f;
    public LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, gndCheckRadius, whatIsGround);

        //jump higher when long press
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetButtonDown("Jump") && isBoxes)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //---joystick---
        //Vector3 moveVector = (Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, 0f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal * moveSpeed , rb.velocity.y);
    }

    private void Flip()
    {
        if((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }

        //--joystick---
        if ((isFacingRight && joystick.Horizontal < 0) || (!isFacingRight && joystick.Horizontal > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boxes"))
        {
            isBoxes = true;
        }
    }
}
