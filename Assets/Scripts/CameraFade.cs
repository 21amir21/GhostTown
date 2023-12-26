using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
	private SpriteRenderer sprite;
	private Color alpha;
	public bool fade = false;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		alpha = new Color(0, 0, 0, 1);
	}

	// Update is called once per frame
	void Update()
	{
		if (fade && alpha.a <= 1)
		{
			alpha.a += Time.deltaTime;
			sprite.color = alpha;
		}
		else if (!fade && alpha.a >= 0)
		{
			alpha.a -= Time.deltaTime;
			sprite.color = alpha;
		}
	}
}
