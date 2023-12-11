using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    public GameObject player;
    private int count = 0;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player gets in contact with lid
        if (collision.collider.tag == "SwimPlayer" && count==0)
        {
            count++;
            FindObjectOfType<SwimmingMovement>().hasLid = true;
            //TODO: make lid child of player
            this.transform.parent = player.transform;
            //transform.SetParent(player.transform, false);
        }
        //TODO: change tag
        if (collision.collider.tag == "Wall")
        {
            this.transform.parent = null;
        }
    }

   
   
  
}
