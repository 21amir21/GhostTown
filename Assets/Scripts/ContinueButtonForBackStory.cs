using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButtonForBackStory : MonoBehaviour
{
	public AudioClip clip;	
    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		AudioManager.instance.PlaySingle(null);
    }


}
