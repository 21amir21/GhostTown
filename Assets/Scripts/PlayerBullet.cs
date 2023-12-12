using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public ABShooting player;

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
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
