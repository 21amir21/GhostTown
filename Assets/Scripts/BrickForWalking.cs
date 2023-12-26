using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickForWalking : MonoBehaviour
{
    public float speed = 5;
    public int damage = 3;
    private GameObject standingEnemy;
    private Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

       
        if (GameObject.FindGameObjectWithTag("Finish").transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndRespawn(damage);
            Destroy(this.gameObject);
        }
    }
}
