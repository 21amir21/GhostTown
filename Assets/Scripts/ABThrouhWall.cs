using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABThrouhWall : MonoBehaviour
{
    public GameObject boo;
    //public GameObject brickWall;
    private SpriteRenderer spriteRendererBoo;
	public bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererBoo = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BrickWall" && isSelected)
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
