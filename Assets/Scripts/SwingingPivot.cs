using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPivot : MonoBehaviour
{
	private float maxAngle = 40;
	private float speed = 1;

	// Update is called once per frame
	void FixedUpdate()
	{
		float angle = maxAngle * Mathf.Sin(Time.time * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
