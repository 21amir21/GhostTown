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

	public TextMeshProUGUI killCount;
	public TextMeshProUGUI totalKillsNeeded;
	public int killCountInt = 0;

	//// barrels
	//public int barrelCountInt = 0;
	//public GameObject barrelPanel;
	//public TextMeshProUGUI barrelCount;
	//public TextMeshProUGUI totalBarrelCount;

	//// timer
	//public GameObject timerPanel;
	//public TextMeshProUGUI timerCount;

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

		killCount.text = "";
		totalKillsNeeded.text = "";

		//timerPanel.SetActive(false);
		//barrelPanel.SetActive(false);
		player = FindObjectOfType<PlayerStats>().gameObject;
		totalKillsNeeded.text = "" + FindObjectOfType<EndOfLevel>().numberOfPeople;
		// Abilities dont work
		// test the rest

	}

	// Update is called once per frame
	void Update()
	{
		health = player.GetComponent<PlayerStats>().health;
		healthBar.fillAmount = health / 100;

		killCountInt = FindObjectOfType<EndOfLevel>().numberOfPeopleKilled;
		killCount.text = "" + killCountInt;

		//barrelCountInt = FindObjectOfType<PlayerStats>().GetBarrelCount();
		//barrelCount.text = "" + barrelCountInt;

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
				boxingGlove.enabled = false;
				brickWall.enabled = false;
				gun.enabled = true;
				tafa.enabled = false;
				break;
			case 3:
				boxingGlove.enabled = false;
				brickWall.enabled = false;
				gun.enabled = false;
				tafa.enabled = true;
				break;
			default:
				break;
		}
	}
}
