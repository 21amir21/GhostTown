using System.Collections;
using UnityEngine;

public class priChasingEnemy : MonoBehaviour
{
    public int damage = 1;
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public Transform bulletpos;
    public GameObject bulletPrefab;
    
    private float timer;
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

        timer+=Time.deltaTime;
        
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
                timer += Time.deltaTime;
                // Move towards the player
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
                if (timer > 2) {
                    timer = 0;
                    Shoot();
                }
            }
            else
            {
                // Stop moving if the player is out of range
                rb.velocity = Vector2.zero;
            }
        }
    }

   
     public void Shoot()
    {
            Instantiate(bulletPrefab, bulletpos.position, Quaternion.identity);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }


}
