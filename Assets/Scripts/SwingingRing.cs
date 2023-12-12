using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingRing : MonoBehaviour
{
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			FindObjectOfType<PlayerStats>().TakeDamageAndDie(10);
		}
	}
}