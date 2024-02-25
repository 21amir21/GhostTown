using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	
	public AudioSource soundEffect;
	public static AudioManager instance = null;
	// Start is called before the first frame update
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip)
	{
		soundEffect.clip = clip;
		soundEffect.Play();
	}

	
}
