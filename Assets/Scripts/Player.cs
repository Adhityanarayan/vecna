using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject boxPrefab;
    public Transform boxHolderPoint;
    public bool isBoxSpawn;
    //BoxCollider2D boxCollider;
    //private void Start()
    //{
    //    boxCollider = GetComponent<BoxCollider2D>();
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        boxCollider.isTrigger = false;
    //        //transform.position = player.BoxHolderPoint.position;
    //        Destroy(gameObject);
    //        SpawnBox();
    //    }
    //}
    private void Update()
    {
        if (isBoxSpawn)
        {
            GameObject box = Instantiate(boxPrefab) as GameObject;
            box.transform.position = boxHolderPoint.position;
            Debug.Log(box.transform.position);
            isBoxSpawn = false;
        }
    }

}
