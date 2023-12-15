using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnKey : MonoBehaviour
{
    private GameObject player;
    private int count = 0;

  

    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && count == 0)
        {
            count++;
            FindObjectOfType<PlayerMovement>().aquiredKey = true;
            //TODO: make key child of player
            this.transform.parent = player.transform;

        }

    }

    public void inActivateKey()
    {
        //TODO: change tag

        Debug.Log("Here");
        transform.parent = null;
        this.gameObject.SetActive(false);

    }

   
}
