using System.Collections;
using UnityEngine;

public class priChasingEnemy : EnemyController
{
    static int policemenkilled=0;
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public Transform bulletpos;
    public GameObject bulletPrefab;
    public GameObject invisibleBox;
    
    private float timer;
    private Transform player;
    private Rigidbody2D rb;

	private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (player.transform.position.x < transform.position.x && isFacingRight)
		{
			Flip();
		}
		else if (player.transform.position.x > transform.position.x && !isFacingRight)
		{
			Flip();
		}

		timer += Time.deltaTime;

		if (player != null)
        {

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if the player is within the detection range
            if (distanceToPlayer <= detectionRange)
            {
				

				// Move towards the player
				Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * moveSpeed;

                // Flip the enemy sprite based on player position
                //if (player.position.x > transform.position.x)
                //{
                //    // Player is on the right side of the enemy
                //    transform.localScale = new Vector3(-3.2897f, 3.0096f, 1); // Flip the sprite
                //}
                //else
                //{
                //    // Player is on the left side of the enemy
                //    //transform.localScale = new Vector3(1f, 1f, 1f); // Reset the sprite scale
                //}

                if (timer > 2)
                {
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
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }



    void Shoot()
    {
            Instantiate(bulletPrefab, bulletpos.position, Quaternion.identity);
    }

    
    private void OnDestroy()
    {
        Debug.Log("ondestroy fel prichasing working fol");
        policemenkilled++;
		FindObjectOfType<VentPolicescene2>().numberOfPeopleKilled++;
        if (policemenkilled >= 3)
        {
            Debug.Log("update bta3 ivBox 48al");
            invisibleBox.SetActive(true);
        }
	}
}
