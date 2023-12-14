using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRod : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public int damageAmount = 10;

    void Update()
    {
        // Rotate the platform around the Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}

