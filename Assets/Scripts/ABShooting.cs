using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABShooting : MonoBehaviour
{

    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;
    private bool shootingAbilityEnabled = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    
// Update is called once per frame
void Update()
    {
        if (shootingAbilityEnabled && Input.GetKeyDown(Return))
        {
            Shooting();
        }   
    }
    public void Shooting()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }


    public void EnableShootingAbility()
    {
        shootingAbilityEnabled = true;
        Debug.Log("shootingAbilityEnabled = true;");
    }



}
