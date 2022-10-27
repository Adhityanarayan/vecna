using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Vector2 screenBounds;

    private BoxGrab boxGrab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        boxGrab = FindObjectOfType<BoxGrab>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(boxGrab.isGrabbed) && collision.gameObject.CompareTag("Player"))
        {
            //boxCollider.isTrigger = false;
            boxGrab.directGrab = true;
            boxGrab.isGrabbed = true;
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            rb.transform.position = boxGrab.boxHolderPoint.position;
            rb.transform.parent = boxGrab.boxHolderPoint;
        }
    }

    public void DirectPick()
    {
        if (boxGrab.isGrabbed)
        {
            boxGrab.directGrab = false;
            boxGrab.isGrabbed = false;
            rb.transform.position = boxGrab.boxDropPoint.position;
            rb.transform.parent = null;
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }*/

    private void FixedUpdate()
    {
        if (rb.transform.position.y < -screenBounds.y - 1)
        {
            Destroy(gameObject);
        }
    }
}