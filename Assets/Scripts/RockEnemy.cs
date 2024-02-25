using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemy : MonoBehaviour
{
	private float timer = 0;
	private float duration = 1.5f;

    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndDie(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((timer += Time.deltaTime) >= duration)
		{
			Destroy(gameObject);
		}
    }
}
