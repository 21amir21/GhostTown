using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTouches : MonoBehaviour
{
    PlayerStats playerStats;
    int numberOfBarrels = 0;
    private Animator animator;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        animator = playerStats.GetComponent<Animator>();
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
            FindObjectOfType<PlayerStats>().CollectBarrel();
            Destroy(gameObject);
        }
    }
}
