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
    private bool isGrounded;
    private bool isBoxes;
    private bool moveLeft, moveRight, isJumping;
    public Transform groundCheck;
    public float gndCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    public float boxCheckRadius = 0.4f;
    public LayerMask whatIsBox;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, gndCheckRadius, whatIsGround);
        isBoxes = Physics2D.OverlapCircle(groundCheck.position, boxCheckRadius, whatIsBox);
        if (moveLeft)
        {
            MoveLeft();
            FlipLeft();
        }
        if (moveRight)
        {
            MoveRight();
            FlipRight();
        }
        if (isJumping && isGrounded)
        {
            Jump();
        }
        if (isJumping && isBoxes)
        {
            Jump();
        }
    }
    public void SetJump(bool isJumping)
    {
        this.isJumping = isJumping;
    }
    public void SetMoveLeft(bool moveleft)
    {
        //Debug.Log("setmoveLeft");
        this.moveLeft = moveleft;
        this.moveRight = !moveleft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = isJumping = false;
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
        float forceY = 0f;
        float vel = Mathf.Abs(rb.velocity.y);

        if (vel < maxVelocityY)
        {
            forceY = jumpForce;
            //anim
        }

        rb.velocity = new Vector2(rb.velocity.x, forceY);
    }
    private void Flip()
    {
        if (moveLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
        if (moveRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1f;
            transform.localScale = scale;
        }
    }
    private void FlipLeft()
    {
        Vector3 scale = transform.localScale;
        if (scale.x > 0f) {
            scale.x *= -1f;
        }
        transform.localScale = scale;
    }
    private void FlipRight()
    {
        Vector3 scale = transform.localScale;
        if (scale.x < 0f)
        {
            scale.x *= -1f;
        }
        transform.localScale = scale;
    }
}
