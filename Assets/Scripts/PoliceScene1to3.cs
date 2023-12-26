using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceScene1to3 : MonoBehaviour
{
    private SpriteRenderer door;
    public GameObject openDoor;
	public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && FindObjectOfType<PlayerMovement>().aquiredKey)
        {
			AudioManager.instance.PlaySingle(clip);
			Invoke("Spawn", 1f);
        }
    }


	void Spawn()
	{
		FindObjectOfType<RespawnKey>().inActivateKey();
		door.sprite = openDoor.GetComponent<SpriteRenderer>().sprite;
		Invoke("NextScene", 0.5f);
	}
	

	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void OnDestroy()
	{
		AudioManager.instance.PlaySingle(null);
	}
}
