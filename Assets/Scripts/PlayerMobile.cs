using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMobile : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    private PlayerMoveMobile playerMoveMobile;
    private BoxGrab boxGrab;

    private void Start()
    {
        playerMoveMobile = GameObject.Find("Player").GetComponent<PlayerMoveMobile>();
        boxGrab = GameObject.Find("Player").GetComponent<BoxGrab>();
    }
    public void OnPointerDown(PointerEventData data)
    {
        //use in canvas button OnClick functionality for click(Down&Up)

        if (gameObject.name == "LeftButton")
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
        //if (gameObject.name == "DropButton")
        //{
        //    Debug.Log("Pick and Drop");
        //    boxGrab.SetpickAndDrop(true);
        //}
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMoveMobile.StopMoving();
        //boxGrab.StoppickAndDrop();
    }

}
