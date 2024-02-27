using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthCanvas : MonoBehaviour
{
	// health and kill count
	private GameObject player;
	public float health;
	public UnityEngine.UI.Image healthBar;

	// ability icons
	public int abilityCount;
	public UnityEngine.UI.Image boxingGlove;
	public UnityEngine.UI.Image brickWall;
	public UnityEngine.UI.Image gun;
	public UnityEngine.UI.Image tafa;

	// Start is called before the first frame update
	void Start()
	{
		boxingGlove.enabled = true;
		brickWall.enabled = false;
		gun.enabled = false;
		tafa.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		health = FindObjectOfType<PlayerStats>().health;
		healthBar.fillAmount = health / 100;

		abilityCount = FindObjectOfType<AbilityManager>().currentAbility;
		switch (abilityCount)
		{
			case 0:
				boxingGlove.enabled = true;
				brickWall.enabled = false;
				gun.enabled = false;
				tafa.enabled = false;
				break;
			case 1:
				boxingGlove.enabled = false;
				brickWall.enabled = true;
				gun.enabled = false;
				tafa.enabled = false;
				break;
			case 2:
				if (FindObjectOfType<AbilityManager>().tafaGained) // if toxic ability is gained
				{
					boxingGlove.enabled = false;
					brickWall.enabled = false;
					gun.enabled = false;
					tafa.enabled = true;
				}
				else // toxic ability not gained
				{
					boxingGlove.enabled = false;
					brickWall.enabled = false;
					gun.enabled = true;
					tafa.enabled = false;
				}
				break;
			default:
				break;
		}
	}
}
