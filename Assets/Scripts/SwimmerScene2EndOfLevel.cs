using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwimmerScene2EndOfLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		FindObjectOfType<CameraFade>().fade = true;
		Invoke("Fade", 1);
	}

	private void Fade()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
