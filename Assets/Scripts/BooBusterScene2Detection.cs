using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooBusterScene2Detection : MonoBehaviour
{
	private SpriteRenderer detectionColor;
	public Sprite yellowZone;
	public Sprite redZone;
	// Start is called before the first frame update
	void Start()
	{
		detectionColor = GetComponent<SpriteRenderer>();
	}

	private void waitYellow()
	{
		detectionColor.sprite = yellowZone;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().TakeDamageAndDie(25);
			detectionColor.sprite = redZone;
			Invoke("waitYellow", 1);
		}
	}
}
