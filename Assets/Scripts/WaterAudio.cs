using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudio : MonoBehaviour
{
	public AudioClip clip;
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		AudioManager.instance.PlaySingle(clip);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		AudioManager.instance.PlaySingle(null);
	}
}
