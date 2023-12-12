using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksinHole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //calling instant death
           // FindObjectOfType<LevelManager>.
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
