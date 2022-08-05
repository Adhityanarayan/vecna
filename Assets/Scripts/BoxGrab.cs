using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGrab : MonoBehaviour
{
    public Transform boxHolderPoint;
    public Transform boxDropPoint;
    public Transform grabDetect;
    public float rayDist;
    public float throwForce = 2f;
    //public LayerMask notGrabbable;

    private RaycastHit2D hit;
    public bool isGrabbed;

    private bool isGrabbingButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGrabbed)
            {
                
                hit = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);
                
                if(hit.collider != null && hit.collider.CompareTag("Boxes"))
                {
                    isGrabbed = true;
                    hit.collider.gameObject.transform.position = boxHolderPoint.position;
                }
            }
            else //if(Physics2D.OverlapPoint(boxHolderPoint.position, notGrabbable))
            {
                isGrabbed = false;

                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1f) * throwForce;
                }
            }

        }

        //uisng ui button
        if (isGrabbingButton)
        {
            PickAndDrop();
        }
        
    }

    public void SetpickAndDrop(bool isGrabbingButton)
    {
        this.isGrabbingButton = isGrabbingButton;
    }
    public void StoppickAndDrop()
    {
        this.isGrabbingButton = false;
    }
    public void PickAndDrop()
    {
        if (!isGrabbed)
        {
            hit = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);

            if (hit.collider != null && hit.collider.CompareTag("Boxes"))
            {
                isGrabbed = true;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                hit.collider.gameObject.transform.position = boxHolderPoint.position;
                hit.collider.gameObject.transform.parent = boxHolderPoint;
            }
        }
        else
        {
            isGrabbed = false;

            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.transform.position = boxDropPoint.position;
                hit.collider.gameObject.transform.parent = null;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(grabDetect.position, grabDetect.position + Vector3.right * transform.localScale.x * rayDist);
    }
}
