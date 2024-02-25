using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public ABShooting player;
	public int damage = 5;
	public bool toxic = false;

	private float timer = 0;
	private float lifeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ABShooting>();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (player.transform.localScale.x < 0)
        {
            // Adjust the speed based on player's scale
            speed = -Mathf.Abs(speed);
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            // Set the velocity directly based on adjusted speed
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            // Set the velocity directly based on original speed
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
		if ((timer += Time.deltaTime) >= lifeTime)
		{
			Destroy(gameObject);
		}

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Policeman")
        {
			other.GetComponent<EnemyController>().EnemyTakeDamage(damage);
			Destroy(gameObject);
        }
		if (other.tag == "BooBuster")
		{
			if (toxic)
			{
				other.GetComponent<EnemyController>().EnemyTakeDamage(damage);
				Debug.Log("Toxic");
			}
			else
			{
				Debug.Log("Not Toxic");
			}
			Destroy(gameObject);
		}
		if (other.tag == "Wall")
		{
			Destroy(gameObject);
		}
    }
}
