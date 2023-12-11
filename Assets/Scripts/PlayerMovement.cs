using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Animation 
	private Animator animator; 

	public float moveSpeed, jumpHeight;
	public float actualMoveSpeed; // TODO: Patrick public for testing

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
	public Transform platform; // TODO: Patrick public for testing
	public GameObject rotatingPlatform;
	public LayerMask platformLayerMask;
	public LayerMask rotatingPlatformLayerMask;
	public LayerMask sandLayerMask;
	private bool isOnPlatform = false;

	// rotation
	private Quaternion defultRotation;

	// Start is called before the first frame update
	void Start()
	{
		checkArea = new Vector2(0.99f, 0.1f); // TODO: Patrick used for gizmo
		rigidBody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		platform = null;
		rotatingPlatform = null;
		defultRotation = Quaternion.identity; // refers to "no rotation" which is 0x, 0y, 0z
        animator = GetComponent<Animator>();
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

        // animation to jump
        animator.SetBool("grounded", grounded);
        // walking animation
        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
    }

	// used for the execution of commands
	private void FixedUpdate()
	{
		// used 50 to mimic the movement speed done by a normal Update() function
		rigidBody.velocity = new Vector2(actualMoveSpeed * Time.fixedDeltaTime * 50, rigidBody.velocity.y);

		// updates grounded to be true whenever the groundCheck circle is in contact with ground
		grounded = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, groundLayerMask);

		// used to check if the player is on a platform and which platform they are on
		PlatformCheck();
	}

	// used as a check to see if the player is standing on a platform
	// returns true if on a platform, false otherwise
	private void PlatformCheck()
	{
		// uses a seperate object at the feet of the player to check if it is overlaping with a platform
		// returns:	an object of type Collider2D if a platform is detected, which is the collider of the platform,
		//			null otherwise
		Collider2D plat = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, platformLayerMask); // Patrick TODO: add comments
		Collider2D rotateHit = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, rotatingPlatformLayerMask); // Patrick TODO: add comments
		Collider2D sandHit = Physics2D.OverlapBox(colliderCheck.position, checkArea, 0f, sandLayerMask); // Patrick TODO: add comments

		if (plat != null)
		{
			isOnPlatform = true;
			platform = plat.transform; // the transform object inside the collider
		}
		else if (rotateHit != null)
		{
			isOnPlatform = true;
			rigidBody.gravityScale = 5; // so that the player can make the platform fall faster and so they slip faster
			rigidBody.freezeRotation = false; // makes the player rotate with the platform
		}
		else if (sandHit != null)
		{
			isOnPlatform = false; // we don't want them to jump if they are on sand
			rigidBody.drag = 5; // slows down the player as if they are walking on sand
		}
		else
		{
			isOnPlatform = false;
			rigidBody.drag = 0; // resets drag as it was changed from sand
			rigidBody.gravityScale = 1; // resets gravity as it was changed from rotating platform
			rigidBody.freezeRotation = true; // freezes z rotation as it was unfrozen from rotating platform
			transform.rotation = Quaternion.RotateTowards(transform.rotation, defultRotation, 1f); // resets the rotation of the player from rotating platform
			rotatingPlatform = null;
			platform = null;
		}
	}

	// used for visualisation in the editor
	void OnDrawGizmos() // TODO: Remove later
	{
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		Gizmos.DrawCube(colliderCheck.position, new Vector3(0.99f, 0.2f, 0f));
	}
}
