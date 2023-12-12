using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPivot : MonoBehaviour
{
	private float time;
	public float startingAngle;
	private readonly float maxAngle = 40;
	private readonly float speed = 2;

	private void Start()
	{
		time = Mathf.Asin(startingAngle);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		time += Time.fixedDeltaTime;
		float angle = maxAngle * Mathf.Sin(time * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
