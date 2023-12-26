using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
	public GameObject pausedScreen;
	public static bool paused;
	public KeyCode PausedButton;

	// Start is called before the first frame update
	void Start()
	{
		paused = false;
		pausedScreen.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(PausedButton) && !paused)
		{
			Paused();
		}
		else if (Input.GetKeyDown(PausedButton) && paused)
		{
			Resume();
		}
	}

	public void Paused()
	{
		pausedScreen.SetActive(true);
		paused = true;
		Time.timeScale = 0;
	}

	public void Resume()
	{
		pausedScreen.SetActive(false);
		paused = false;
		Time.timeScale = 1;
	}
}
