using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private SpriteRenderer yellowToRed;
    public Sprite redZone;
    // Start is called before the first frame update
    void Start()
    {
        yellowToRed = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            yellowToRed.sprite = redZone;
           // Object.Destroy(gameObject, .3f);
            FindObjectOfType<PlayerStats>().TakeDamage(100);
        }
    }
}
