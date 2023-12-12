using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingGround : MonoBehaviour
{
    public int damageAmount = 10;       // Amount of damage per second
    public float damageInterval = 1f;    // Time interval between damage ticks

    private float nextDamageTime;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            // Check if enough time has passed to deal damage again
            if (Time.time >= nextDamageTime)
            {
                // Deal damage to the player
                FindObjectOfType<PlayerStats>().TakeDamage(damageAmount);

                // Set the next time damage will be dealt
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}

