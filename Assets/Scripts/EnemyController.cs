using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //VARIABLES FOR ALL ENEMIES SPEED AND DAMAGE //
    public float speed;
    public int damage = 5;
    public bool isFacingRight = false;

    // this is to trigger the damage function for the player//
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }


    // take damage of the enemy
    public int health = 3;
    public float flickerDura1on = 0.1f;
    private float flickerTime = 0f;
    public SpriteRenderer spriteRenderer;


    public void EnemyTakeDamage(int damage)
    {
        // enemy taking damage from whatever ability
        health = health - damage;
        // flickering to indicate damage 
       // SpriteFlicker(sprite);
       
        if(health <= 0)
        {
            health = 0;
        }

        // if enemy is dead
       if (health == 0)
        {
            Debug.Log("Enemy Finished"); 
            Destroy(gameObject);
        }
    }

    //TODO: CHECK IF FLICKERING WORKS ON INHERETED ENEMIES
    void SpriteFlicker(SpriteRenderer sprite)
    {
        if (flickerTime < flickerDura1on)
        {
            flickerTime = flickerTime + Time.deltaTime;
        }
        else if (flickerTime >= flickerDura1on)
        {
            sprite.enabled = !(sprite.enabled);
            this.flickerTime = 0;
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
