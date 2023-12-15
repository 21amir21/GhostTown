using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceScene1to2 : MonoBehaviour
{
    private SpriteRenderer door;
    public Sprite openDoor;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<SpriteRenderer>();
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door.sprite = openDoor;
			Invoke("NextScene", 1);
		}
    }
	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
