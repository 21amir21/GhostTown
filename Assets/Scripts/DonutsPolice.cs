using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutsPolice : EnemyController
{
    public ABShooting playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = FindObjectOfType<ABShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            FindObjectOfType<ABShooting>().EnableShootingAbility();
        }
    }

   

}
