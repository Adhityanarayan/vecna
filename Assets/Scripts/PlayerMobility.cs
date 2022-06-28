using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{
    Rigidbody2D rb;
    private float deltaX,deltaY;

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
            deltaY = touchPos.y - transform.position.y;
            // horizontal swipe
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                //right
                if (deltaX > 0)
                {
                    Debug.Log("right");
                    deltaX = touchPos.x - transform.position.x;
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.localPosition.y));
                    FlipRight();
                }
                //left
                else if (deltaX < 0)
                {
                    Debug.Log("left");
                    deltaX = touchPos.x - transform.position.x;
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.localPosition.y));
                    FlipLeft();
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                {
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.localPosition.y));
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }
    void CalculateSwipeDirection(float deltaX, float deltaY)
    {
      

        // horizontal swipe
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            //right
            if (deltaX > 0)
            {
                Debug.Log("right");
                //direction = SwipeDirection.Right;
                FlipRight();
            }
            //left
            else if (deltaX < 0)
            {
                Debug.Log("left");
                //direction = SwipeDirection.Left;
                FlipLeft();
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
