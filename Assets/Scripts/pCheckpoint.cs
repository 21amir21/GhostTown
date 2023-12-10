using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        //if the collider of the object whose name is Sonic GameObject touches the checkPoint's circle collider
        if (Other.tag == "Player")
            FindObjectOfType<LevelManager>().currentCheckpoint = gameObject;
    }
}
