using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player GameObject
    public Vector3 offset;    // Offset between the player and the camera

    void Update()
    {
        if (player != null)
        {
            // Set the camera's position to the player's position plus the offset
            transform.position = player.position + offset;
        }
        else
        {
            Debug.LogWarning("Player reference not set in CameraFollow script. Please assign the player GameObject in the Inspector.");
        }
    }
}