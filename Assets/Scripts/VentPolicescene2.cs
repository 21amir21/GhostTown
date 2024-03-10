using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPolicescene2 : MonoBehaviour
{
	private SpriteRenderer policevent;
	public Sprite policeopenvent;

	public int numberOfPeople;
	public int numberOfPeopleKilled = 0;
	public TextMeshProUGUI peoplecount;
	public TextMeshProUGUI killcount;

	// Start is called before the first frame update
	void Start()
	{
		policevent = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		peoplecount.text = "" + numberOfPeople;
		killcount.text = "" + numberOfPeopleKilled;

		if (numberOfPeople == numberOfPeopleKilled)
		{
			Debug.Log("Here");
			//script.SetActive(true);
			FindObjectOfType<FocusOnVent>().enabled = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && numberOfPeopleKilled >= numberOfPeople)
		{
			policevent.sprite = policeopenvent;
			FindObjectOfType<CameraFade>().fade = true;
			Invoke("Fade", 1);
		}
	}

	private void Fade()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
