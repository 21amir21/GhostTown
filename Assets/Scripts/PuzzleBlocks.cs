using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocks : MonoBehaviour
{

    //float deltaX, deltaY;
    //bool colTouched = false;
    //Rigidbody2D rb;
    //bool selected = false;
    //Vector3 mousePosition;
    //float timer = 0;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    rb.bodyType = RigidbodyType2D.Static;
    //}

    //private void Update()
    //{
    //    if (selected == true)
    //    {
            
    //    }
    //     mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    //if left click
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //if mouse is over component (tile is selected)
    //        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
    //        {
    //            colTouched = true;
    //            rb.isKinematic = false;
    //            deltaX = mousePosition.x - transform.position.x;
    //            deltaY = mousePosition.y - transform.position.y;
    //        }
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        colTouched = false;
    //        rb.bodyType= RigidbodyType2D.Static;
            
    //        rb.velocity = Vector2.zero;
    //    }

    //    //if mouse is moving
    //    if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
    //    {

    //        //if mouse is selecting tile
    //        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition) && colTouched)
    //        {
    //            if (mousePosition.x < transform.position.x || mousePosition.y < transform.position.y)
    //            {
    //                rb.velocity = new Vector2(-1, -1);
    //                rb.bodyType = RigidbodyType2D.Kinematic;
                   
    //            }
    //            else if (mousePosition.x > transform.position.x || mousePosition.y > transform.position.y)
    //            {
    //                rb.velocity = new Vector2(1, 1);
                   
    //                rb.bodyType = RigidbodyType2D.Kinematic;
    //            }
    //        //    else
    //        //    {
    //        //        rb.velocity = Vector2.zero;
    //        //    }

    //        //    //rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));
    //        }
    //        //else
    //        //{
    //        //    blockIsMoving = false;
    //        //    rb.velocity = Vector2.zero;
    //        //}
    //    }

       


    //}



    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (mousePosition.x < transform.position.x || mousePosition.y < transform.position.y)
    //    {
    //        rb.velocity = new Vector2(1, 1);
    //        rb.bodyType = RigidbodyType2D.Kinematic;
    //        blockIsMoving = true;
    //    }
    //    else if (mousePosition.x > transform.position.x || mousePosition.y > transform.position.y)
    //    {
    //        rb.velocity = new Vector2(-1, -1);
    //        blockIsMoving = true;
    //        rb.bodyType = RigidbodyType2D.Kinematic;
    //    }


    //}

    float deltaX, deltaY;
    bool colTouched = false;
    Rigidbody2D rb;
    bool selected = false;
    float timer = 0.0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //if mouse is over component (tile is selected)
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

        //if mouse is moving
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {

            //if mouse is selecting tile
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition) && colTouched)
            {

                rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));
            }
        }


    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if(collision.contacts > transform.position.x)
    //    //{

    //    //}
    //    if (timer < 1)
    //    {
    //        selected = true;
    //    }
    //    timer += Time.deltaTime;
    //    if (timer > 1)
    //    {
    //        selected = false;
    //        rb.MovePosition(new Vector2(transform.position.x - 0.2f, transform.position.y));
    //    }
    //}

    //void MovingMouse()
    //{

    //}

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
