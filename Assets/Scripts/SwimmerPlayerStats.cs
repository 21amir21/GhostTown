//attached to player
//controls health and lives

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerPlayerStats : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;

    private float flickerTime = 0f;
    public float filckerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }


    private void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    public void takeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.health == 0 && this.lives > 0)
            {
                //FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
        }
        PlayHitReaction();
    }
    private void SpriteFlicker()
    {
        if (this.flickerTime < this.filckerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.filckerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }

}

