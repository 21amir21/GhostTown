using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    private int hitCount = 0;
    public GameObject torn;
    public Transform crab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< Updated upstream
        if (collision.tag == "SwimPlayer" )
            hitCount++;
=======
        hitCount++;
        if (collision.tag == "SwimPlayer")
>>>>>>> Stashed changes
        {
            //if player aquired crab
            if (FindObjectOfType<SwimmingMovement>().aquiredCrab)
            {
                gameObject.SetActive(false);
                torn.SetActive(true);
                FindObjectOfType<Crab>().inActivateCrab();
               
            }
            //if crab was not yet aquired and this is the first time player collides with net
            //TODO: spawn the crab
            else if (FindObjectOfType<SwimmingMovement>().aquiredCrab == false && hitCount == 1)
            {
                crab.gameObject.SetActive(true);
                FindObjectOfType<LevelManager>().RespawnEnemy();
                //TODO: Make camera zoom on crab and pause play
                //while (Time.deltaTime < 5)
                //{
                //FindObjectOfType<CameraFollowPri>().Target=crab;

                //}
            }
        }
    }

}
