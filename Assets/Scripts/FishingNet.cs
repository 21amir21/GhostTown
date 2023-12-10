using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    private int hitCount = 0;
    public Sprite tornNet;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitCount++;
        if (collision.tag == "Player")
        {
            //if player aquired crab
            if (FindObjectOfType<SwimmingMovement>().aquiredCrab)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = tornNet;
                gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            }
            //if crab was not yet aquired and this is the first time player collides with net
            else if (FindObjectOfType<SwimmingMovement>().aquiredCrab == false && hitCount == 1)
            {

            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    hitCount++;
    //    if(collision.collider.tag == "Player")
    //    {
    //        //if player aquired crab
    //        if(GetComponent<SwimmingMovement>().aquiredCrab == true)
    //        {
    //            //this.GetComponent<SpriteRenderer>().sprite = tornNet;
    //        }
    //        //if crab was not yet aquired and this is the first time player collides with net
    //        else if(GetComponent<SwimmingMovement>().aquiredCrab == false && hitCount ==1)
    //        {

    //        }
    //    }
    //}
}
