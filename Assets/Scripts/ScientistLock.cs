using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistLock : MonoBehaviour
{
    public GameObject playpuzzel;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && counter== 1)
        {

            playpuzzel.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playpuzzel.SetActive(false);
        }
    }


    public void policeCounter()
    {
        counter++;
    }
}
