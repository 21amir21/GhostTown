using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentPolicescene2 : MonoBehaviour
{
    private SpriteRenderer policevent;
    public Sprite policeopenvent;
	public int numberOfPeople;
	public int numberOfPeopleKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        policevent = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && numberOfPeople == numberOfPeopleKilled)
        {
            policevent.sprite = policeopenvent;
			Invoke("NextScene", 0.5f);
        }
    }

	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
