using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScientistLock : MonoBehaviour
{
    public GameObject playpuzzel;
    public int counter = 0;
	public KeyCode interactKey;

	private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && counter >= 1)
        {
            playpuzzel.SetActive(true);
			
			if (Input.GetKeyDown(interactKey))
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
