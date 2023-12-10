using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Punching : MonoBehaviour
{

    public KeyCode punchingkey;
    public GameObject boohand;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        boohand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(punchingkey)) { 

            boohand.SetActive(true);

            //animation 
        
        }
        if (Input.GetKeyUp(punchingkey))
        {
            boohand.SetActive(false);

        }
    }
}
