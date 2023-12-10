using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABThrouhWall : MonoBehaviour
{
    public GameObject boo;
    //public GameObject brickWall;
    public SpriteRenderer spriteRendererBoo;
    // Start is called before the first frame update
    void Start()
    {
        spriteRendererBoo = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ThroughWall()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BrickWall")
        {
            boo.GetComponent<BoxCollider2D>().enabled = false;

            if (!spriteRendererBoo.flipX)
            {
                boo.transform.position = new Vector3(boo.transform.position.x + 1.2f, boo.transform.position.y, boo.transform.position.z);
            }
            else
            {
                boo.transform.position = new Vector3(boo.transform.position.x - 1.2f, boo.transform.position.y, boo.transform.position.z);
            }

            boo.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
