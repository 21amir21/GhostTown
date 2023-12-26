using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTouches : MonoBehaviour
{
    PlayerStats playerStats;
    int numberOfBarrels = 0;
    private Animator animator;
	public AudioClip clip;
    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        animator = playerStats.GetComponent<Animator>();
		FindObjectOfType<PlayerBullet>().toxic = true;
    }

    private void Update()
    {
        numberOfBarrels = playerStats.GetBarrelCount();
        // Debug.Log("Number of barrels: " + numberOfBarrels);
        if (numberOfBarrels == 2)
        {
            animator.SetInteger("Greeness", 1);
        }
        else if (numberOfBarrels == 4)
        {
            animator.SetInteger("Greeness", 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			AudioManager.instance.PlaySingle(clip);
           Invoke("BarrelCollection", 0.3f);
        }
    }

	void BarrelCollection()
	{
		FindObjectOfType<PlayerStats>().CollectBarrel();
		Destroy(gameObject);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			AudioManager.instance.PlaySingle(null);
		}
	}
}
