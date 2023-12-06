using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint; //we can update the current checkpoint from within Unity
    public Transform player;
    public Transform Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerMovement>().transform.position = CurrentCheckpoint.transform.position;
        //Search for the asset/object called Controller (ur player's script code name whatever it is).
        //once u've found it, change its player game object's position to be at the last checkpoint the
        //player passed through before s/he died ..
    }
}
