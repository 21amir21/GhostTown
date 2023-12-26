using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PenguinPunchActual : EnemyController
{
	// movement
	private bool isActive = false;
	private Rigidbody2D rb;
	private GameObject player;
	public GameObject penguinHand;
	private float distance;

	// punch timer
	private float punchTimer = 0;
	private float punchCooldown = 2;

	// punch duration
	private float punchDuration = 0.5f;
	private bool isPunching = false;
	
	// Start is called before the first frame update
	void Start()
	{
		penguinHand.SetActive(false);
		speed = -2;
		isFacingRight = false;
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!isActive && player.transform.position.y < -34)
		{
			isActive = true;
		}

		if (isActive)
		{
			// flip if the player is on the other side
			if (player.transform.position.x < transform.position.x && isFacingRight)
			{
				Flip();
				speed *= -1;
			}
			else if (player.transform.position.x > transform.position.x && !isFacingRight)
			{
				Flip();
				speed *= -1;
			}

			punchTimer += Time.fixedDeltaTime;

			rb.velocity = new Vector2(speed, rb.velocity.y);

			// calculate distance between player and penguin
			distance = Vector2.Distance(transform.position, player.transform.position);

			// if they are punching and the punch duration has passed then stop punching
			if (punchTimer > punchDuration && isPunching)
			{
				isPunching = false;
				penguinHand.SetActive(false);
			}

			// if they are not punching and the punch cooldown has passed and they are close enough then punch
			if (distance < 4 && punchTimer > punchCooldown)
			{
				Punch();
			}
		}
	}

	private void Punch()
	{
		punchTimer = 0;
		penguinHand.SetActive(true);
		isPunching = true;
	}

	private void OnDestroy()
	{
		GameObject[] floors;
		floors = GameObject.FindGameObjectsWithTag("Ground");

		// splits the ground thats not under the player
		if (player.transform.position.x < 104)
			floors[1].SetActive(false);
		else
			floors[0].SetActive(false);

		FindObjectOfType<EndOfLevel>().numberOfPeopleKilled++;
	}
}
