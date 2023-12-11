using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicWaste : SwimEnemyController
{// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SwimPlayer")
        {
            FindObjectOfType<SwimmerPlayerStats>().takeDamage(damage);
            // FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}
