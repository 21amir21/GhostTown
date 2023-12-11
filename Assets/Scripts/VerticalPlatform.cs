using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    Vector3 startingPosition;
    public float maxTop, maxBottom, speed;
    private float currentX;
    bool hasReachedBottom;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // initialises starting position with the position of the platform at the start
        currentX = startingPosition.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (hasReachedBottom) // reached min height
        {
            if (transform.position.y < maxTop - 0.1f) // still not yet at the max height
            {
                Vector2 finalPosition = new Vector2(currentX, maxTop);
                Move(finalPosition);
            }
            else // reached max height
            {
                hasReachedBottom = false;
            }
        }
        else // reached max height
        {
            if (transform.position.y > maxBottom + 0.1f) // still not yet at the min height
            {
                Vector2 finalPosition = new Vector2(currentX, maxBottom);
                Move(finalPosition);
            }
            else // reached min height
            {
                hasReachedBottom = true;
            }
        }
    }

    private void Move(Vector2 finalPosition)
    {
        // similar to Lerp but makes the movement a constant speed instead of slowing down as it gets closer to the final position
        transform.position = Vector2.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }
}
