using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    //public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
       // winText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //winText.gameObject.SetActive(true);
        Debug.Log("You Won");
        //TODO: go back to level
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
