using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
	public int numberOfPeople;
	public int numberOfPeopleKilled = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((collision.CompareTag("Player") || collision.CompareTag("SwimPlayer") || collision.CompareTag("Finish")) && numberOfPeopleKilled >= numberOfPeople)
		{
			FindObjectOfType<CameraFade>().fade = true;
			Invoke("Fade", 1);
		}
		else if ((collision.CompareTag("Player") || collision.CompareTag("SwimPlayer") || collision.CompareTag("Finish")) && numberOfPeopleKilled < numberOfPeople)
		{
			// TODO: display a message to the player that they need to kill all the enemies
			Debug.Log("You need to kill all the enemies");
		}
	}

	private void Fade()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
