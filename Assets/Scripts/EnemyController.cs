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
    private SpriteRenderer spriteRenderer;


    public void EnemyTakeDamage(int damage)
    {
        // enemy taking damage from whatever ability
        this.health = this.health - damage;
        // flickering to indicate damage 
        SpriteFlicker();
       
        // if enemy is dead
       if (this.health == 0)
        {
            Debug.Log("Enemy Finished"); 
            Destroy(this.gameObject);
        }
    }

    //TODO: CHECK IF FLICKERING WORKS ON INHERETED ENEMIES
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDura1on)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDura1on)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
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
