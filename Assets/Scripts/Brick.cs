using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float speed =5;
    public int damage=3;
    private PlayerMovement player;
    private GameObject standingEnemy;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<PlayerMovement>();
        standingEnemy = GameObject.FindWithTag("Enemy");
        if(standingEnemy.transform.localScale.x<0)
        {
            speed = -speed;
            transform.localScale = new Vector3((-transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity= new Vector2(speed,rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
