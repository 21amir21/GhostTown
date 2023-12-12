using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocks : MonoBehaviour
{
    float deltaX, deltaY;
    bool colTouched = false;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
            {
                colTouched = true;
                rb.isKinematic = false;
                deltaX = mousePosition.x - transform.position.x;
                deltaY = mousePosition.y - transform.position.y;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            colTouched = false;
            rb.isKinematic = true;
        }

        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {
            if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition) && colTouched)
            {
                rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));
            }
        }


    }



    //private Vector3 mousePosition;
    //public float moveSpeed = 0.1f;
    //private bool selected = false;
    //private bool collided = false;


    //// Use this for initialization
    //void Start()
    //{

    //}


    //private void OnMouseOver()
    //{
    //    selected = true;
    //    //if (Input.GetMouseButton(0))
    //    //{


    //    //    //mousePosition = Input.mousePosition;
    //    //    //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    //    //transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

    //    //}
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    collided = true;
    //    //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if(selected && collided && Input.GetMouseButton(0))
    //    {
    //        mousePosition = Input.mousePosition;
    //        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    //    }
    //    else
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //    }


    //}

    //private void FixedUpdate()
    //{
    //    //selected = false;
    //    //collided = false;
    //}
}
