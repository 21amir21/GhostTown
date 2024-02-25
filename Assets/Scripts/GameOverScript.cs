using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
	string previousScene;
	public AudioClip clip;

	// Start is called before the first frame update
	void Start()
	{
		AudioManager.instance.PlaySingle(clip);
		
		Debug.Log("game over screen");
		previousScene = SceneManager.GetSceneAt(0).name;
		SceneManager.UnloadSceneAsync(previousScene);
	}

	public void GameOverActivation()
	{
		AudioManager.instance.PlaySingle(null);
        SceneManager.LoadScene(previousScene);
		Invoke("LoadLevel", 0.5f);
	}

	private void LoadLevel()
	{
        SceneManager.UnloadSceneAsync(0);
    }
}
