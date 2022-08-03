using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMobile : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    public float moveSpeed = 2f;
    public float maxVelocity = 4f;
    public float maxVelocityY = 16f;
    public float jumpForce = 14f;

    private bool moveLeft, moveRight, isJumping;
    private bool isGrounded;
    private bool isBoxes;
    public Transform groundCheck;
    public float gndCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, gndCheckRadius, whatIsGround);
    }

    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }
        if (moveRight)
        {
            MoveRight();
        }
        if (isJumping && isGrounded)
        {
            Jump();
        }
        if (isJumping && isBoxes)
        {
            Jump();
        }

        Flip();
    }

    public void SetMoveLeft(bool moveleft)
    {
        Debug.Log("setmoveLeft");
        this.moveLeft = moveleft;
        this.moveRight = !moveleft;
    }
    public void SetJump(bool isJumping)
    {
        this.isJumping = isJumping;
    }
    public void StopMoving()
    {
        moveLeft = moveRight = false;
        isJumping = false;
        //anim.SetBool("Walk", false);
    }
    public void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = -moveSpeed;
            //anim.SetBool("Walk", true);

        }

        //rb.AddForce(new Vector2(forceX, 0));
        rb.velocity = new Vector2(forceX, rb.velocity.y);
    }
    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = moveSpeed;
            //anim.SetBool("Walk", true);

        }

        //rb.AddForce(new Vector2(forceX, 0));
        rb.velocity = new Vector2(forceX, rb.velocity.y);
    }

    public void Jump()
    {
        if(rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        //float forceY = 0f;
        //float vel = Mathf.Abs(rb.velocity.y);

        //if (vel < maxVelocityY)
        //{
        //    forceY = jumpForce;
        //    //anim
        //}

        //rb.velocity = new Vector2(rb.velocity.x, forceY);
    }

    private void Flip()
    {
        if (moveLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        if (moveRight)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
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
