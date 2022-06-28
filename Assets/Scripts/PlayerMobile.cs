using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobile : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveMobile playerMoveMobile;
    public bool isClicked;
    private void Start()
    {
        playerMoveMobile = GameObject.Find("Player").GetComponent<PlayerMoveMobile>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && isClicked)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                //Debug.Log("Left");
                playerMoveMobile.SetMoveLeft(true);
            }
        }
        if (Input.touchCount > 0 && isClicked)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                //Debug.Log("Right");
                playerMoveMobile.SetMoveLeft(false);
            }
        }
        if( Input.touchCount  == 0)
        {
            playerMoveMobile.StopMoving();
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "JumpButton")
        {
            isClicked = false;
            Debug.Log("Jump");
            playerMoveMobile.SetJump(true);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMoveMobile.StopMoving();
        isClicked = true;
    }
}
