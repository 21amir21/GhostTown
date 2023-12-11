using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBox : MonoBehaviour
{
    public int policeKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (policeKilled == 0)
        {
            gameObject.SetActive(true);
        }
    }

    public void PoliceManKilled()
    {
        policeKilled++;
        Debug.LogWarning("policeKilled++");
        
    }
}
