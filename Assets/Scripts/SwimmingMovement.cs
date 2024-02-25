using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingMovement : MonoBehaviour
{
	public KeyCode up;
	public KeyCode down;
	public KeyCode L;
	public KeyCode R;
	public float moveSpeed;
	private Rigidbody2D rigid;
	//checks if character is swimming down
	private bool isFacingDown;
	public bool aquiredCrab;
	public bool hasLid;
	public bool isFacingRight = true;

	private Animator anim;



	// Start is called before the first frame update
	void Start()
	{
		hasLid = false;
		aquiredCrab = false;
		isFacingDown = false;
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	private void unfreezeMovement()
	{
		//unfreeze when no key is pressed
		rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
		rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
		rigid.freezeRotation = true;
	}

	// Update is called once per frame
	void Update()
	{
		rigid.freezeRotation = true;

		if (Input.GetKey(up) && Input.GetKey(R))
		{
			isFacingRight = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, moveSpeed);
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(up) && Input.GetKey(L))
		{
			isFacingRight = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, moveSpeed);
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(down) && Input.GetKey(L))
		{
			isFacingRight = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, -moveSpeed);
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(down) && Input.GetKey(R))
		{
			isFacingRight = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, -moveSpeed);
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(up))
		{
			isFacingDown = false;
			rigid.constraints = RigidbodyConstraints2D.FreezePositionX;

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, moveSpeed);

			if (GetComponent<SpriteRenderer>() != null)
			{
				GetComponent<SpriteRenderer>().flipY = false;
			}

			unfreezeMovement();
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(down))
		{

			isFacingDown = true;
			rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -moveSpeed);

			//if (GetComponent<SpriteRenderer>() != null)
			//{
			//	GetComponent<SpriteRenderer>().flipY = true;
			//}
			unfreezeMovement();
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
		}
		else if (Input.GetKey(L))
		{
			isFacingRight = false;
			//if character was swimming down
			//if (isFacingDown == true)
			//{
			//	//flip it upwards
			//	GetComponent<SpriteRenderer>().flipY = false;
			//	isFacingDown = false;
			//}
			rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

			if (GetComponent<SpriteRenderer>() != null)
			{
				GetComponent<SpriteRenderer>().flipX = true;
			}

			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
			unfreezeMovement();
		}
		else if (Input.GetKey(R))
		{
			isFacingRight = true;
			//if (isFacingDown == true)
			//{
			//	//flip it upwards
			//	GetComponent<SpriteRenderer>().flipY = false;
			//	isFacingDown = false;
			//}
			//freeze Y
			rigid.constraints = RigidbodyConstraints2D.FreezePositionY;

			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			if (GetComponent<SpriteRenderer>() != null)
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}
			unfreezeMovement();
		}
		//"Speed" parameter name in Animator
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
	}

}


