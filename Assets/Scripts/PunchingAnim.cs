using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchingAnim : MonoBehaviour
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
        punching = false;    
        
    }

 
    public void Punch()
    {

            boohand.SetActive(true);
            punching = true;
            //animation
            animator.SetBool("punching", punching);

    }

    public void StopPunch()
    {
        boohand.SetActive(false);
        punching = false;
        animator.SetBool("punching", punching);
    }
}
