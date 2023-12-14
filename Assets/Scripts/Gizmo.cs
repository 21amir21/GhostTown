using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
	BoxCollider2D box;

	private void OnDrawGizmos()
	{
		box = GetComponent<BoxCollider2D>();
		Gizmos.color = Color.red;
		Gizmos.DrawCube(box.bounds.center, box.bounds.size);
	}
}
