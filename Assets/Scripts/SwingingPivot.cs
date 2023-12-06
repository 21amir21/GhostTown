using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPivot : MonoBehaviour
{
	HingeJoint2D joint;
	JointMotor2D temp;

	// Start is called before the first frame update
	void Start()
	{
		joint = GetComponent<HingeJoint2D>();
		temp = joint.motor;
		Debug.Log(joint.limits.max);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// TODO: Make it like a pendulum
		if (joint.limitState == JointLimitState2D.LowerLimit && temp.motorSpeed < 0)
		{
			temp.motorSpeed = -temp.motorSpeed;
			joint.motor = temp;
		}
		if (joint.limitState == JointLimitState2D.UpperLimit && temp.motorSpeed > 0)
		{
			temp.motorSpeed = -temp.motorSpeed;
			joint.motor = temp;
		}
	}
}
