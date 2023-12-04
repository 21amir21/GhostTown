using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
	Vector3 startingPosition;
	public float maxLeft, maxRight, speed;
	private float currentY;
	bool hasReachedLeft;

	// Start is called before the first frame update
	void Start()
	{
		startingPosition = transform.position; // initialises starting position with the position of the platform at the start
		currentY = startingPosition.y;
	}

	// Update is called once per frame
	void Update()
	{
		//hi
	}

	private void FixedUpdate()
	{
		if (hasReachedLeft) // reached max left
		{
			if (transform.position.x < maxRight - 0.1f) // still not yet at the max right
			{
				Vector2 finalPosition = new Vector2(maxRight, currentY);
				Move(finalPosition);
			}
			else // reached max right
			{
				hasReachedLeft = false;
			}
		}
		else // reached max right
		{
            if (transform.position.x > maxLeft + 0.1f) // still not yet at the max left
            {
                Vector2 finalPosition = new Vector2(maxLeft, currentY);
                Move(finalPosition);
            }
            else // reached max left
            {
                hasReachedLeft = true;
            }
        }
	}

	private void Move(Vector2 finalPosition)
	{
		// similar to Lerp but makes the movement a constant speed instead of slowing down as it gets closer to the final position
		transform.position = Vector2.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }
}
