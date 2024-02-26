using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	public int currentAbility = 0;
	public int abilityCount;
	private static AbilityManager instance = null;
	private bool isSwimmerScene2 = false;
	public bool abilityGained = false;
	public bool tafaGained = false;

	private KeyCode switchAbility = KeyCode.LeftAlt;
	private KeyCode useAbility = KeyCode.Space;

	public AudioClip clip;
	public AudioClip clip2;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		abilityCount = 0;
	}

	private void Update()
	{
		if (GameObject.FindWithTag("Penguin"))
		{
			if (currentAbility == 2)
				nextAbility();
		}

		if (GameObject.FindWithTag("SwimPlayer"))
		{
			isSwimmerScene2 = true;
		}
		else
		{
			isSwimmerScene2 = false;
		}

		if (Input.GetKeyDown(switchAbility) && !isSwimmerScene2)
		{
			nextAbility();
		}

		//if (Input.GetKey(useAbility) && !isSwimmerScene2)
		//{
		//	switch (currentAbility)
		//	{
		//		case 0: // Punch
		//			AudioManager.instance.PlaySingle(clip);
		//			// TODO: Patrick Punch
		//			break;
		//		case 2: // Shoot
		//			AudioManager.instance.PlaySingle(clip2);

		//			break;
		//		default:
		//			break;
		//	}
		//}
		if ((Input.GetKeyDown(useAbility) && !isSwimmerScene2))
		{
			switch (currentAbility)
			{
				case 0: // Punch
					AudioManager.instance.PlaySingle(clip);
					FindObjectOfType<PunchingAnim>().Punch(); // TODO: Patrick Punch
					break;
				case 2: // Shoot
					AudioManager.instance.PlaySingle(clip2);
					FindObjectOfType<ABShooting>().Shooting();
					break;
				default:
					break;
			}
		}
		else if (Input.GetKeyUp(useAbility))
		{
			AudioManager.instance.PlaySingle(null);
			FindObjectOfType<PunchingAnim>().StopPunch();
		}
	}

	public void addConstruction()
	{
		abilityCount = 1;
	}

	public void addShooting()
	{
		abilityCount = 2;
	}

	public void addTafa()
	{
		tafaGained = true;
	}

	public void nextAbility()
	{
		currentAbility++;

		if (currentAbility > abilityCount)
		{
			currentAbility = 0;
		}

		if (currentAbility == 1)
		{
			FindObjectOfType<ABThrouhWall>().isSelected = true;
		}
		else
		{
			FindObjectOfType<ABThrouhWall>().isSelected = false;
		}

		Debug.Log(currentAbility);
	}
}