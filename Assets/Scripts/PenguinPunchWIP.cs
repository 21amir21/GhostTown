using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinPunchWIP : EnemyController
{
	// movement
	private Rigidbody2D rb;
	private GameObject player;
	public GameObject penguinHand;
	private float distance;
	
	private float punchTimer = 0;
	private float punchCooldown = 2;

	private float punchDuration = 0.5f;
	private bool isPunching = false;

	private float moveTimer = 0;
	private float moveCooldown = 0.6f;

	// Start is called before the first frame update
	void Start()
	{
		isFacingRight = false;
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void FixedUpdate()
	{
		if (player.transform.position.x < transform.position.x && isFacingRight)
		{
			Flip();
		}
		else if (player.transform.position.x > transform.position.x && !isFacingRight)
		{
			Flip();
		}

		punchTimer += Time.fixedDeltaTime;
		moveTimer += Time.fixedDeltaTime;

		float randomValue;

		if (!isFacingRight && moveTimer > moveCooldown)
		{
			randomValue = Random.Range(-5, 2) * 2;
		}
		else
		{
			randomValue = Random.Range(-2, 5) * 2;
		}

		// vertical and horizontal check

		//// calculate vertical movement only if the player is not above the penguin
		//float verticalMove = 0f;
		//if (player.transform.position.y - transform.position.y < 3)
		//{
		//	verticalMove = Random.Range(-3, 3) * 3;
		//}

		rb.velocity = new Vector2(randomValue, rb.velocity.y);

		distance = Vector2.Distance(transform.position, player.transform.position);

		// if they are punching and the punch duration has passed then stop punching
		if (punchTimer > punchDuration && isPunching)
		{
			penguinHand.SetActive(false);
		}

		// if they are not punching and the punch cooldown has passed and they are close enough then punch
		if (distance < 2 && punchTimer > punchCooldown)
		{
			Punch();
		}
	}

	private void Punch()
	{
		punchTimer = 0;
		penguinHand.SetActive(true);
	}
}
