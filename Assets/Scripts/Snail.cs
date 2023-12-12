using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
	public GameObject player;
	private Rigidbody2D rigidBody;
	private bool startChase = false;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (player.transform.position.x > -10.5f)
			startChase = true;

		if (startChase)
		{
			rigidBody.velocity = new Vector2(3, rigidBody.velocity.y);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && startChase)
		{
			FindObjectOfType<PlayerStats>().KillPlayer(); // TODO: Patrick uncomment
			Debug.Log("ded"); // TODO: Patrick remove
		}
	}
}