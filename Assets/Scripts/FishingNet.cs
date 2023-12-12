using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    private int hitCount = 0;
    public GameObject torn;
    public Transform crab;
    public Transform player;
    public GameObject rock;



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
        if (collision.tag == "SwimPlayer" || collision.tag=="Enemy")
        {
            hitCount++;
            //if player aquired crab
            if (FindObjectOfType<SwimmingMovement>().aquiredCrab)
            {
                gameObject.SetActive(false);
                torn.SetActive(true);
                FindObjectOfType<Crab>().inActivateCrab();
               
            }
            //if crab was not yet aquired and this is the first time player collides with net
            else if (FindObjectOfType<SwimmingMovement>().aquiredCrab == false && hitCount == 1)
            {
                crab.gameObject.SetActive(true);
                SpawnCrab();
              
            }
        }
    }

    private void SpawnCrab()
    {
        Instantiate(crab, rock.transform.position, rock.transform.rotation);
        FindObjectOfType<FocusOnCrab>().CrabCameraEnable();
    }


}

