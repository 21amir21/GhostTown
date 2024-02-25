using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollection : MonoBehaviour
{
	public AudioClip clip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			AudioManager.instance.PlaySingle(clip);
            Invoke("CollectBarrel", 0.3f);
        }
    }
	private void CollectBarrel()
	{
		FindObjectOfType<PlayerStats>().CollectBarrel();
		Debug.Log(FindObjectOfType<PlayerStats>().GetBarrelCount());
		Object.Destroy(gameObject);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			AudioManager.instance.PlaySingle(null);
		}
	}
}
