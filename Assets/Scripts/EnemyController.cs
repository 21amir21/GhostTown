using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	// take damage of the enemy
	public int health = 10;

	//VARIABLES FOR ALL ENEMIES SPEED AND DAMAGE //
	public float speed;
	public int damage = 5;
	public bool isFacingRight = false;
	public bool isPoliceWithKey = false;
	// this is to trigger the damage function for the player//
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().TakeDamageAndDie(damage);
		}
	}

	public void Flip()
	{
		isFacingRight = !isFacingRight;
		transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
	}

	public void EnemyTakeDamage(int damage)
	{
		// enemy taking damage from whatever ability
		health -= damage;

		if (health <= 0)
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

	private void OnDestroy()
	{
		FindObjectOfType<EndOfLevel>().numberOfPeopleKilled++;
	}
}
