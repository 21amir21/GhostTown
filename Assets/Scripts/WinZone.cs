using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
		Debug.Log("WinZone");
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("PoliceScene 3"));
        SceneManager.UnloadSceneAsync("Puzzle");
    }
}
