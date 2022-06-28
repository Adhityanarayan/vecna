using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject box;
    public Transform boxGround;
    public Transform boxHolderPoint;
    public Transform grab;
    public Transform player;
    public Transform ClimbDetect;
    public bool isBoxSpawn = true;
    BoxCollider2D boxCollider;
    public bool isSelected;
    public bool canHold;
    public float rayDist;
    private RaycastHit2D hit;
    private void Start()
    {
        //T = transform.Find("BoxHolderPoint");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!isBoxSpawn)
        {
            box.transform.position = boxHolderPoint.position;
            isSelected = true;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2)
            {
                //box.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1f);
                if (isSelected)
                {
                    isSelected = false;
                    box.transform.position = grab.position;
                }
                isBoxSpawn = true;
                box.isStatic = false;
            }
            if(touch.tapCount == 3)
            {
                hit = Physics2D.Raycast(ClimbDetect.position, Vector2.right * transform.localScale.x, rayDist);
                if (hit.collider != null && hit.collider.CompareTag("OriginalBox"))
                {
                    //hit.collider.gameObject.transform.position = boxHolderPoint.position;
                    boxGround = hit.collider.gameObject.transform;
                    player.transform.position = new Vector2(boxGround.position.x, boxGround.position.y + 0.56f);
                }
                
            }
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
            //boxGround = new GameObject();
            //boxGround.transform.parent = box.transform;
        }       
        canHold = false;
        isBoxSpawn = false;
    }
}
