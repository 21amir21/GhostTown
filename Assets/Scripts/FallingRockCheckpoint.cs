using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FallingRockCheckpoint : MonoBehaviour
{
    private float duration=2f;
    private float timer = 0f;
    public Transform Rock;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            FallingRock();
            timer = 0f; 
        }   
    }

    void FallingRock()
    {
        Instantiate(Rock, transform.position, transform.rotation);
    }

}
