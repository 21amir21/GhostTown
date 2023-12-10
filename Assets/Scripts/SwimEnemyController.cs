//in an empty script file in assests

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimEnemyController : MonoBehaviour
{
    public int damage = 3;

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SwimmerPlayerStats>().takeDamage(damage);
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
