using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScientistLock : MonoBehaviour
{
	public Scene puzzle;

    public GameObject playpuzzel;
    private int counter = 0;
	public KeyCode interactKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && counter== 1)
        {
            playpuzzel.SetActive(true);
		}
    }

	private void Update()
	{
		if (Input.GetKeyDown(interactKey))
		{
			playpuzzel.SetActive(false);
			SceneManager.LoadScene(puzzle.buildIndex, LoadSceneMode.Additive);
		}

		// Check if the puzzle is loaded
		if (puzzle.isLoaded)
		{
			if (Input.GetKeyDown(interactKey))
			{
				// Unloads the camera in the police scene
				SceneManager.GetActiveScene().GetRootGameObjects()[0].SetActive(false);
				// Set the puzzle scene as the active scene
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("Puzzle"));
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playpuzzel.SetActive(false);
        }
    }

    public void policeCounter()
    {
        counter++;
    }
}
