using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damageAmount = 10;       // Amount of damage per second
    public float damageInterval = 1f;    // Time interval between damage ticks

    private float nextDamageTime;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if enough time has passed to deal damage again
            if (Time.time >= nextDamageTime)
            {
                // Deal damage to the player
                FindObjectOfType<PlayerStats>().TakeDamageAndDie(damageAmount);

                // Set the next time damage will be dealt
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if enough time has passed to deal damage again
            if (Time.time >= nextDamageTime)
            {
                // Deal damage to the player
                FindObjectOfType<PlayerStats>().TakeDamageAndDie(damageAmount);

                // Set the next time damage will be dealt
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
   
}

