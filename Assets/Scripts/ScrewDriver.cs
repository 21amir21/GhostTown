using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision) //TODO: change tag
    {
        if (collision.CompareTag("Player") && count == 0)
        {
            count++;
            FindObjectOfType<PlayerMovement>().screwDriverIsAccquired = true;
            //TODO: make crab child of player
            this.transform.parent = player.transform;

        }

    }

    public void inActivateScrewDriver()
    {
        //TODO: change tag

        Debug.Log("Here ya Amir");
        transform.parent = null;
        this.gameObject.SetActive(false);

    }
}
