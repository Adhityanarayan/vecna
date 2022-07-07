using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOnHead : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject box;
    public Transform boxHolderPoint;
    public bool isBoxSpawn;

    public bool canHold;

    private void Start()
    {

    }

    private void Update()
    {
        if (!isBoxSpawn)
        {
            box.transform.position = boxHolderPoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boxes"))
        {
            SpawnBox();
            canHold = true;
        }
    }
    public void SpawnBox()
    {
        if (canHold && isBoxSpawn)
        {
            box = Instantiate(boxPrefab) as GameObject;
        }
        canHold = false;
        isBoxSpawn = false;
    }
}

