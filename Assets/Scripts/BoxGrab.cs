using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGrab : MonoBehaviour
{
    public Transform boxHolderPoint;
    public Transform grabDetect;
    public float rayDist;
    public float throwForce = 2f;
    //public LayerMask notGrabbable;

    private RaycastHit2D hit;
    private bool isGrabbed;

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

                    hit.collider.gameObject.transform.parent = this.transform;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
            else //if(Physics2D.OverlapPoint(boxHolderPoint.position, notGrabbable))
            {
                isGrabbed = false;
                hit.collider.gameObject.transform.parent = null;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1f) * throwForce;
                }
            }


        }

        /*//alternate
        hit = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);

        if (hit.collider != null && hit.collider.CompareTag("Boxes"))
        {
            if (Input.GetKey(KeyCode.P))
            {
                isGrabbed = true;
                hit.collider.gameObject.transform.parent = boxHolderPoint;
                hit.collider.gameObject.transform.position = boxHolderPoint.position;

                //hit.collider.gameObject.transform.parent = this.transform;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                hit.collider.gameObject.transform.parent = null;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(grabDetect.position, grabDetect.position + Vector3.right * transform.localScale.x * rayDist);
    }
}
