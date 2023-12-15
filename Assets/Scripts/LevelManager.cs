using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public Vector3 currentCheckpoint; // we can update the current checkpoint from within Unity
	public Transform player;

	// Start is called before the first frame update
	void Start()
	{
		currentCheckpoint = player.transform.position;
	}

	[Obsolete("Use RestartScene instead unless you actually mean to use respawn")]
	public void RespawnPlayer()
	{
		player.transform.position = currentCheckpoint;
		//Search for the asset/object called Controller (ur player's script code name whatever it is).
		//once u've found it, change its player game object's position to be at the last checkpoint the
		//player passed through before s/he died ..
	}
	public void RestartScene()
	{
		// reloads the scene to reset everything that was changed
		// params are string which is the name of the scene so it restarts the scene that is currently active
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}