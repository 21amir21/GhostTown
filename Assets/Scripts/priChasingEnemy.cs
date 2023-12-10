using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class priChasingEnemy : MonoBehaviour
{
    public int damage = 1;
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public Transform firepoint;
    
    private Transform player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                // Move towards the player
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                // Stop moving if the player is out of range
                rb.velocity = Vector2.zero;
            }
        }


    }
    void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }

    }
    
}