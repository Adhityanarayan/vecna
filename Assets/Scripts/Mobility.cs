using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobility : MonoBehaviour
{
    Rigidbody2D rb;
    private float deltaX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get rb
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            deltaX = touchPos.x - transform.position.x;
            if (deltaX > 0)
            {
                Debug.Log("right");
                FlipRight();
            }
            //left
            else
            {
                Debug.Log("left");
                FlipLeft();
            }

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    break;
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.localPosition.y));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }      
    private void FlipLeft()
    {
        Vector3 scale = transform.localScale;
        if (scale.x > 0f)
        {
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
