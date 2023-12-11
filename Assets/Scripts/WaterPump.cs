using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPump : MonoBehaviour
{
    public GameObject lid;
    public GameObject pump;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player has the lid
        if (FindObjectOfType<SwimmingMovement>().hasLid==true)
        {
            
            //TODO: make lid cover pump
            lid.transform.position = new Vector3(pump.transform.position.x - lid.GetComponent<BoxCollider2D>().size.x, pump.transform.position.y, pump.transform.position.z);
            lid.transform.parent = pump.transform;
            //make water bubbles dissapear and allow player to pass by
            gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
