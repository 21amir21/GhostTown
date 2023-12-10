using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


using UnityEngine;

public class Punching : MonoBehaviour
{


    public KeyCode punchingkey;
    public GameObject boohand;
    private Animator animator;
    private bool punching;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boohand.SetActive(false);
        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(punchingkey))
            {

                boohand.SetActive(true);
                punching = true;
                //animation
                animator.SetBool("punching", punching);

            }
            if (Input.GetKeyUp(punchingkey))
            {
                boohand.SetActive(false);
                punching = false;
            }

        }
    }
}
