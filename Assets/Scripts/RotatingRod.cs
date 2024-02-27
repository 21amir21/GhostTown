using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRod : MonoBehaviour
{
	public float rotationSpeed = 45f;
	public int damageAmount = 10;
	public AudioClip clip;

	private void Start()
	{
		FindObjectOfType<AbilityManager>().addTafa();
	}

	void Update()
	{
		// Rotate the platform around the Z-axis
		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the colliding object is the player
		if (collision.gameObject.CompareTag("Player"))
		{
			AudioManager.instance.PlaySingle(clip);
			// Deal damage to the player
			PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
			if (playerHealth != null)
			{
				playerHealth.TakeDamageAndDie(damageAmount);
			}
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			AudioManager.instance.PlaySingle(clip);
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			AudioManager.instance.PlaySingle(null);
		}
	}

	private void OnDestroy()
	{
		AudioManager.instance.PlaySingle(null);
	}
}