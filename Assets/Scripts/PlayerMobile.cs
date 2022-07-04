using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobile : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveMobile playerMoveMobile;
    private Player player;
    public bool isClicked;
    private void Start()
    {
        playerMoveMobile = GameObject.Find("Player").GetComponent<PlayerMoveMobile>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && isClicked)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2 && (touch.position.y > Screen.height * 0.2f))
            {
                //Debug.Log("Left");
                playerMoveMobile.SetMoveLeft(true);
            }
        }
        if (Input.touchCount > 0 && isClicked)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2 && (touch.position.y > Screen.height * 0.2f))
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
        if (gameObject.name == "DropButton")
        {
            isClicked = false;
            Debug.Log("Drop");
            player.DropBox();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMoveMobile.StopMoving();
        isClicked = true;
    }
}
