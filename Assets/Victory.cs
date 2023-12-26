using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
	public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySingle(clip);
    }



}
