using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLadder21 : MonoBehaviour
{
    public GameObject fixedLadder;
    public Transform screwDriver;
    public GameObject player;
	public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //if player aquired crab
            if (FindObjectOfType<PlayerMovement>().screwDriverIsAccquired)
            {
				AudioManager.instance.PlaySingle(clip);
				Invoke("FixeLadder", 2f);
               

            }


        }
    }
	void FixeLadder()
	{
		gameObject.SetActive(false);
		fixedLadder.SetActive(true);
		FindObjectOfType<ScrewDriver>().inActivateScrewDriver();
	}

}
