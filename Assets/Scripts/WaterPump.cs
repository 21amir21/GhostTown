using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPump : MonoBehaviour
{
    public GameObject obj;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player has the lid
        if (FindObjectOfType<SwimmingMovement>().hasLid==true)
        {
            //TODO: make lid cover pump

            //make water bubbles dissapear and allow player to pass by
            obj.GetComponent<BoxCollider2D>().enabled = false;
            obj.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
