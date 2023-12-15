using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceScene1to3 : MonoBehaviour
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
        if (other.tag == "Player" && FindObjectOfType<PlayerMovement>().aquiredKey)
        {
            FindObjectOfType<RespawnKey>().inActivateKey();
            door.sprite = openDoor;
            Invoke("NextScene", 0.5f);
        }
    }

	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
