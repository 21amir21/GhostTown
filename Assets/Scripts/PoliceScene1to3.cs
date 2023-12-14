using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScene1to3 : MonoBehaviour
{
    private SpriteRenderer door;
    public Sprite openDoor;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && FindObjectOfType<PlayerMovement>().aquiredKey)
        {
            FindObjectOfType<RespawnKey>().inActivateKey();
            door.sprite = openDoor;
            //go to police scene 3
        }
    }
}
