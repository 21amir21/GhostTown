using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player gets in contact with lid
        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<SwimmingMovement>().hasLid = true;
            //TODO: make lid child of player

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
