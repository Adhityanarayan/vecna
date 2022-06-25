using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobile : MonoBehaviour
{
    private PlayerMoveMobile playerMoveMobile;

    private void Start()
    {
        playerMoveMobile = GameObject.Find("Player").GetComponent<PlayerMoveMobile>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                //Debug.Log("Left");
                playerMoveMobile.SetMoveLeft(true);
            }
        }
        if (Input.touchCount > 0)
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

}
