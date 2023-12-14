using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    private SpriteRenderer box;
    public Sprite fallBox;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player" && (collision.GetContact(0).point.y > transform.position.y))
        {   // switching  out the sprites 
            box.sprite = fallBox;
            // sprite disappearing
            UnityEngine.Object.Destroy(gameObject, 1.5f);
        }


    }
}
