using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneTimer : MonoBehaviour
{
    // this is a timer for the  boobuster scene 1 
    private float timeToStop = 90f;
	public AudioClip clip;
    public TextMeshProUGUI timer;
    private int roundedtime;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySingle(clip);
    }

    // Update is called once per frame
    void Update()
    {
        roundedtime= Mathf.RoundToInt(timeToStop);  
        timer.text = "" + roundedtime;
        timeToStop -= Time.deltaTime;
        
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
