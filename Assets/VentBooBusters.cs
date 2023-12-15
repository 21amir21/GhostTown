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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && FindObjectOfType<PlayerStats>().GetBarrelCount() == 7) 
        {
            vent.sprite = openVent;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
