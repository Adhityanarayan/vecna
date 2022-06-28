using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Rigidbody2D rb;
    BoxCollider2D boxCollider;
    private Vector2 screenBounds;
    private void Start()
    {
     
        //Debug.Log(boxHolderPoint);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //boxCollider.isTrigger = false;
            //rb.isKinematic = true;
            Destroy(gameObject);
            //canTransform = true;

        }
    }
    //private void SpawnBox()
    //{
    //    GameObject box = Instantiate(boxVariantPrefab) as GameObject;
    //    box.transform.position = boxHolderPoint.position;
    //}

    private void FixedUpdate()
    {
        if(rb.transform.position.y < -screenBounds.y - 1)
        {
            Destroy(gameObject);
        }
    }
}
