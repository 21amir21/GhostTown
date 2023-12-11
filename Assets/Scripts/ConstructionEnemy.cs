using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionEnemy : EnemyController
{

    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Return))
        {
            Shooting();
        }   
    }
    public void Shooting()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
