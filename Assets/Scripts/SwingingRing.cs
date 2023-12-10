using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingRing : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			//TODO: Patrick take damage
		}
	}
}
