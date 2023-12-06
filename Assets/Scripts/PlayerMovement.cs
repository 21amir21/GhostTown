using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed, jumpHeight;
	public float actualMoveSpeed; // TODO: public for testing

	private Rigidbody2D rigidBody;
	private SpriteRenderer sprite;

	// input keys
	public KeyCode upArrow, leftArrow, rightArrow;

	// grounded check
	public Transform colliderCheck;
	public Vector2 checkArea;
	public LayerMask groundLayerMask;
	private bool grounded;

	// platform check
	public Transform platform; // TODO: public for testing
	public LayerMask platformLayerMask;
	private bool isOnPlatform = false;

	// Start is called before the first frame update
	void Start()
	{
		checkArea = new Vector2(0.99f, 0.1f);
		rigidBody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		platform = null;
	}

	// Update is called once per frame
	// used for receiving the inputs from the user and simple commands
	void Update()
	{
		actualMoveSpeed = 0;
		if (Input.GetKey(rightArrow))
		{
			actualMoveSpeed = moveSpeed; // to be used later in FixedUpdate()

			if (sprite != null)
			{
				sprite.flipX = false; // faces right
			}
		}
		if (Input.GetKey(leftArrow))
		{
			actualMoveSpeed = -moveSpeed;// to be used later in FixedUpdate()

			if (sprite != null)
			{
				sprite.flipX = true; // faces left
			}
		}
		// if player presses up arrow key and is grounded then jumps
		if (Input.GetKey(upArrow) && (grounded || isOnPlatform))
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
		}
		// when they release the up arrow key stops all vertical
		// velocity and starts droping, if the player wasn't already droping
		else if (Input.GetKeyUp(upArrow) && rigidBody.velocity.y > 0)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
		}

		// setting the platform as the parent of player if standing on a platform
		if (platform != null)
			transform.parent = platform;
		else
			transform.parent = null;

		isOnPlatform = PlatformCheck();
	}

	// used for the execution of commands for the physics engine
	private void FixedUpdate()
	{
		// used 50 to mimic the movement speed done by a normal Update() function
		rigidBody.velocity = new Vector2(actualMoveSpeed * Time.fixedDeltaTime * 50, rigidBody.velocity.y);

		// updates grounded to be true whenever the colliderCheck circle is in contact with ground
        grounded = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, groundLayerMask);
    }

    // used as a check to see if the player is standing on a platform
    // returns true if on a platform, false otherwise
    private bool PlatformCheck()
	{
		// uses a seperate object at the feet of the player to check if it is overlaping with a platform
		// returns:	an object of type Collider2D if a platform is detected, which is the collider of the platform,
		//			null otherwise
		Collider2D hit = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, platformLayerMask); // TODO: add comments

		if (hit != null)
		{
			isOnPlatform = true;
			platform = hit.transform; // the transform object inside the collider
		}
		else
		{
			isOnPlatform = false;
			platform = null;
		}

		return platform != null;
	}

	// used for visualisation in the editor
	void OnDrawGizmos() // TODO: Remove later
	{
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		Gizmos.DrawCube(colliderCheck.position, new Vector3(0.99f, 0.2f, 0f));
	}
}
