using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : VentPolicescene2
{
	//public Script script;

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
			//script.SetActive(true);
			FindObjectOfType<FocusOnVent>().enabled = true;
        }
    }
}
