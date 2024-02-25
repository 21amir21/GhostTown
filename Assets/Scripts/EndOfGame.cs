using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
	public AudioClip clip;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Finish") && FindObjectOfType<PlayerStats>().GetBarrelCount() == 4)
		{
			AudioManager.instance.PlaySingle(clip);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Finish") && FindObjectOfType<PlayerStats>().GetBarrelCount() == 4)
		{
			AudioManager.instance.PlaySingle(null);
		}
	}
}
