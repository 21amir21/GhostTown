using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
	public GameObject player;
	private Rigidbody2D rigidBody;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rigidBody.velocity = new Vector2(4, rigidBody.velocity.y);
	}
}
