using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishController : SwimEnemyController
{
    public bool isMovingUp = true;
    public float maxSpeed = 5f;


    public void Flip()
    {
        isMovingUp = !isMovingUp;

    }

    private void FixedUpdate()
    {
        if (this.isMovingUp == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, maxSpeed);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -maxSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SwimPlayer")
        {
            FindObjectOfType<SwimmerPlayerStats>().takeDamage(damage);
            Flip();
        }
<<<<<<< Updated upstream
        else if (other.tag == "Corals")
=======
        else if (other.tag == "shPlatform")
>>>>>>> Stashed changes
        {
            Flip();
        }
        else if (other.tag == "Enemy")
        {
            Flip();
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
