using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
	public bool isPLayerColliding = false;
	private Quaternion defultRotation;
	private Rigidbody2D rigidBody;

	// Start is called before the first frame update
	void Start()
	{
		defultRotation = Quaternion.identity;
		rigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!isPLayerColliding)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, defultRotation, 0.7f);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			isPLayerColliding = true;
			FindObjectOfType<PlayerMovement>().rotatingPlatform = gameObject;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			isPLayerColliding = false;
			rigidBody.angularVelocity = 0;
			FindObjectOfType<PlayerMovement>().rotatingPlatform = null;
			Debug.Log("ih");
		}
	}
}