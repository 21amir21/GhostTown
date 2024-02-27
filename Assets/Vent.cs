using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : EndOfLevel
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfPeople == numberOfPeopleKilled)
        {
            Debug.Log("Here");
            FindObjectOfType<FocusOnVent>().VentCameraEnable();
        }
    }
}
