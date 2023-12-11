using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minY = 0f;
    public float maxY = 5f;

    private int direction = 1; // 1 for up, -1 for down

    void Update()
    {
        // Move the platform vertically
        transform.Translate(Vector3.up * direction * moveSpeed * Time.deltaTime);

        // Check if the platform reached the upper or lower bounds
        if (transform.position.y >= maxY)
        {
            direction = -1; // Change direction to move down
        }
        else if (transform.position.y <= minY)
        {
            direction = 1; // Change direction to move up
        }
    }
}


