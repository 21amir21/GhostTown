using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTimer : MonoBehaviour
{
    // this is a timer for the  boobuster scene 1 
    private float timeToStop = 90f;
	public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySingle(clip);
    }

    // Update is called once per frame
    void Update()
    {
        timeToStop-= Time.deltaTime;    
        if(timeToStop < 0)
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndDie(100);
        }
    }

	private void OnDestroy()
	{
		AudioManager.instance.PlaySingle(null);
	}
}
