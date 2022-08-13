using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject square;
    //public Vector2 randX;
    //public Vector2 randY;

    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    //private Vector2 spawnPos;

    //private void FixedUpdate()
    //{
    //    spawnPos.x = Random.Range(randX.x, randX.y);
    //    spawnPos.y = Random.Range(randY.x, randY.y);
    //    Instantiate(boxPrefab, spawnPos, Quaternion.identity);
    //}

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnBox();
    }
    private void SpawnBox()
    {
        GameObject box = Instantiate(square) as GameObject;
        box.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y - randomNumber());

    }

    private int randomNumber()
    {
        return (int)Random.Range(screenBounds.y / 2, screenBounds.y / 2);
    }

}