using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
	public int health; // TODO: Patrick make all private
	public int maxHealth = 100;
	public float flickerDura1on = 0.1f;
	private float flickerTime = 0f;
	private SpriteRenderer spriteRenderer;
	public bool isImmune = false;
	public float immunityDura1on = 1.5f; //el w2t ely sonic 3mal ynor w ytfy
	private float immunityTime = 0f;
    private int barrelCount = 0;

    // public int coinsCollected = 0;
    void Start()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		health = maxHealth;
	}
	// Update is called once per frame
	void Update()
	{
		if (isImmune == true)
		{
			SpriteFlicker();
			immunityTime += Time.deltaTime;
			if (immunityTime >= immunityDura1on)
			{
				isImmune = false;
				spriteRenderer.enabled = true;
			}
		}
	}

	[Obsolete("Use TakeDamageAndRespawn or TakeDamageAndDie instead")]
	public void TakeDamage(int damage)
	{
		TakeDamageAndRespawn(damage);
	}

	public void TakeDamageAndRespawn(int damage)
	{
		if (isImmune == false)
		{
			health -= damage;
			if (health < 0)
				health = 0;
			if (health == 0)
			{
				Debug.Log("Gameover"); // TODO: add game over splash screen
				FindObjectOfType<LevelManager>().RespawnPlayer();
			}
			Debug.Log("Player Health : " + health.ToString()); // TODO: Remove
			PlayHitReac1on();
		}
	}

	public void TakeDamageAndDie(int damage)
	{
		if (isImmune == false)
		{
			health -= damage;

			if (health < 0)
				health = 0;
			if (health == 0)
			{
				KillPlayer();
			}
			Debug.Log("Player Health : " + health.ToString()); // TODO: Remove
			PlayHitReac1on();
		}
	}

	/// <summary>
	/// Make sure to put a timer during the function call so the damage is not applied every frame
	/// </summary>
	public void TakeDamageOverTime(int damage) // TODO: remove if not used
	{
		health -= damage;
		if (health < 0f)
			health = 0;
		if (health == 0)
		{
			KillPlayer();
		}
	}
	void PlayHitReac1on()
	{
		isImmune = true;
		immunityTime = 0f;
	}
	void SpriteFlicker()
	{
		if (flickerTime < flickerDura1on)
		{
			flickerTime += Time.deltaTime;
		}
		else if (flickerTime >= flickerDura1on)
		{
			spriteRenderer.enabled = !(spriteRenderer.enabled);
			flickerTime = 0;
		}
	}

	public void KillPlayer()
	{
		Debug.Log("Gameover"); // TODO: add game over splash screen
		FindObjectOfType<LevelManager>().RestartScene();
	}

	public void CollectBarrel()
	{
		barrelCount++;
	}

	public int GetBarrelCount()
	{
		return barrelCount;
	}
} //Class