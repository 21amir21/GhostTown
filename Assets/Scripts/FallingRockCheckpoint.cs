using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class FallingRockCheckpoint : MonoBehaviour
{
    private float duration=0.8f;
    private float timer = 0f;
    public Transform Rock;
    public float rockRandomRespawn;
	public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            FallingRock();
            timer = 0f; 
        }
    }

    void FallingRock()
    {
        rockRandomRespawn = UnityEngine.Random.Range(29.91f, 69.63f);
        transform.position = new Vector3(rockRandomRespawn, transform.position.y, transform.position.z);
        Instantiate(Rock, transform.position, transform.rotation);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			AudioManager.instance.PlaySingle(clip);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			AudioManager.instance.PlaySingle(null);
		}
	}
}
