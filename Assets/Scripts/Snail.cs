using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
	public GameObject player;
	private Rigidbody2D rigidBody;
	private bool startChase = false;
	private Animator animator;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		if (player.transform.position.x > -10.5f)
			startChase = true;
		if (transform.position.x > 90)
			startChase = false;

		if (startChase)
		{
			rigidBody.velocity = new Vector2(3, rigidBody.velocity.y);
		}

		animator.SetBool("Moving", startChase);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && startChase)
		{
			FindObjectOfType<PlayerStats>().KillPlayer();
		}
	}
}