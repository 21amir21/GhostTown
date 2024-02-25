using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPolicescene2 : MonoBehaviour
{
	private SpriteRenderer policevent;
	public Sprite policeopenvent;
	//public int numberOfPeople;
	//public int numberOfPeopleKilled = 0;

	// Start is called before the first frame update
	void Start()
	{
		policevent = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		//numberOfPeople = FindObjectOfType<EndOfLevel>().numberOfPeople;
		//numberOfPeopleKilled = FindObjectOfType<EndOfLevel>().numberOfPeopleKilled;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			policevent.sprite = policeopenvent;
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
