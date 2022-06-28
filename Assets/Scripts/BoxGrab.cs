using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxGrab : MonoBehaviour
{
    public Transform boxHolderPoint;
    public Transform grabDetect;
    public float rayDist;
    public float throwForce = 2f;
    public bool canGrab;
    //public LayerMask notGrabbable;

    private RaycastHit2D hit;
    private bool isGrabbed;

    private void Update()
    {

            if (!isGrabbed)
            {
                hit = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);
                if (hit.collider != null && hit.collider.CompareTag("Boxes"))
                {
                    isGrabbed = true;
                    hit.collider.gameObject.transform.position = boxHolderPoint.position;
                }
            }
            else //if(Physics2D.OverlapPoint(boxHolderPoint.position, notGrabbable))
            {
                isGrabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1f);
                }
            }
    }

        //    if (gameObject.name == "RightButton")
        //    {
        //        Debug.Log("Right");
        //        playerMoveMobile.SetMoveLeft(false);
        //    }
        //    if (gameObject.name == "JumpButton")
        //    {
        //        Debug.Log("Jump");
        //        playerMoveMobile.SetJump(true);
        //    }
        //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(grabDetect.position, grabDetect.position + Vector3.right * transform.localScale.x * rayDist);
    }
}
