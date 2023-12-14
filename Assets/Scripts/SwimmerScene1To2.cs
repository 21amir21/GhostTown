using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerScene1To2 : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// TODO: Patrick - Load scene 2
		}
	}
}
