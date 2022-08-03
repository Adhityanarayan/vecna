using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobile : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    private PlayerMoveMobile playerMoveMobile;

    private void Start()
    {
        playerMoveMobile = GameObject.Find("Player").GetComponent<PlayerMoveMobile>();
    }
    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name == "LeftButton")
        {
            Debug.Log("Left");
            playerMoveMobile.SetMoveLeft(true);
        }
        if(gameObject.name == "RightButton")
        {
            Debug.Log("Right");
            playerMoveMobile.SetMoveLeft(false);
        }
        if (gameObject.name == "JumpButton")
        {
            Debug.Log("Jump");
            playerMoveMobile.SetJump(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMoveMobile.StopMoving();
    }

}
