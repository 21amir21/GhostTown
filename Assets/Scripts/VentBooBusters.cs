using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentBooBusters : MonoBehaviour
{
	private SpriteRenderer vent;
    public Sprite openVent;

    // Start is called before the first frame update
    void Start()
    {
        vent = GetComponent<SpriteRenderer>();
		//FindObjectOfType<HealthCanvas>().totalBarrelCount.text = "/8";
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && FindObjectOfType<PlayerStats>().GetBarrelCount() == 8) 
        {
            vent.sprite = openVent;
			FindObjectOfType<CameraFade>().fade = true;
			Invoke("Fade", 1);
		}
	}

	private void Fade()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
