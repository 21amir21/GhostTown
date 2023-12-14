using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
	private int currentAbility = 0;
	public int abilityCount = 0;
	private static AbilityManager instance = null;

	private KeyCode switchAbility = KeyCode.Tab;
	private KeyCode useAbility = KeyCode.Space;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != null)
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(switchAbility))
		{
			nextAbility();
		}

		if (Input.GetKeyDown(useAbility))
		{
			switch (currentAbility)
			{
				case 0: // Punch
					FindObjectOfType<PunchingAnim>().Punch(); // TODO: Patrick Punch
					break;
				case 2: // Shoot
					FindObjectOfType<ABShooting>().Shooting();
					break;
				default:
					break;
			}
		}
		else if (Input.GetKeyUp(useAbility) && currentAbility == 0)
		{
			FindObjectOfType<PunchingAnim>().StopPunch();
		}
	}

	public void addAbility()
	{
		abilityCount++;
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
