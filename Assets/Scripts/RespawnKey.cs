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

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && count == 0)
        {
            count++;
            FindObjectOfType<PlayerMovement>().aquiredKey = true;
            //TODO: make crab child of player
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
