using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject boxVariantPrefab;
    //public Transform boxHolderPoint;
    private Rigidbody2D rb;
    BoxCollider2D boxCollider;
    private Vector2 screenBounds;
    //public Transform t;
    private Player player;
    private void Update()
    {
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCollider.isTrigger = false;
            //rb.isKinematic = true;
            //transform.position = player.BoxHolderPoint.position;
            Destroy(gameObject);
            player.isBoxSpawn = true;
            SpawnBox();
        }
    }
    private void SpawnBox()
    {
        GameObject box = Instantiate(boxVariantPrefab) as GameObject;
        box.transform.position = player.boxHolderPoint.position;
    }

    private void FixedUpdate()
    {
        if(rb.transform.position.y < -screenBounds.y - 1)
        {
            Destroy(gameObject);
        }
    }
}
