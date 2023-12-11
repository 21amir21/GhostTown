using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private GameObject player;
    private int count =0;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("PlayerUnderwater");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SwimPlayer" && count == 0)
        {
            count++;
            FindObjectOfType<SwimmingMovement>().aquiredCrab = true;
            //TODO: make crab child of player
            this.transform.parent = player.transform;

        }
        
    }

    public void inActivateCrab()
    {
        //TODO: change tag
       
            Debug.Log("Here");
            transform.parent = null;
            this.gameObject.SetActive(false);
        
    }
}
