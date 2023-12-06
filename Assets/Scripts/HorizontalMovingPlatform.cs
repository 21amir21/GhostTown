using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    public float speed = 5f;  // Speed of the platform
    public float leftBound = -5f;  // Leftmost position of the platform
    public float rightBound = 5f;  // Rightmost position of the platform

    private bool movingRight = true;

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Move the platform horizontally based on the current direction
        float direction = movingRight ? 1f : -1f;
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Change direction when reaching the bounds
        if (transform.position.x >= rightBound)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftBound)
        {
            movingRight = true;
        }
    }
}

