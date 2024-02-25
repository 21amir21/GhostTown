using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
   
    public float leftLimit;
    public float rightLimit;

   void FixedUpdate()
    {
        if(this.isFacingRight == true)
        {
           
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
            if (transform.position.x >= rightLimit)
            {
                Flip();
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.GetComponent<Rigidbody2D>().velocity.y);
            if (transform.position.x <= leftLimit)
            {
                Flip();
            }
        }
    }

  
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Wall")
        {
            Flip();
        }
        else if (collider.tag == "Enemy")
        {
            Flip();
        }
	
        if(collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndRespawn(damage);
            Flip();
        }
    }
}
