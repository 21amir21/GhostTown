using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    private int damage = 10;

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            FindObjectOfType<PlayerStats>().TakeDamageAndDie(damage); // TODO: Patrick, change this to TakeDamageOverTime
        }
    }

}
