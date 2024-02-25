using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistPolice : priChasingEnemy
{
    static int scipolicemenkilled = 0;
    public GameObject invlock;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Debug.Log("ondestroy fel prichasing working fol");
        scipolicemenkilled++;
        FindObjectOfType<ScientistLock>().policeCounter();
        if (scipolicemenkilled == 1)
        {
            Debug.Log("update bta3 ivBox 48al");
            invlock.SetActive(true);


        }
    }
}
