using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{

    private Sprite sprite;
    public Sprite OpentreasureSprite;
    public int damage;
    public GameObject lid;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        if (sprite == OpentreasureSprite || FindObjectOfType<SwimmingMovement>().hasLid)
        {
            lid.GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            lid.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collided with treasure while it's not opened
        if(collision.tag=="SwimPlayer" && !(sprite == OpentreasureSprite))
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndDie(damage);
        }
       
    }
}
