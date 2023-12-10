using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    
    public KeyCode punchkey;
    public int damage = 2;
    private Animator animator;
    private bool ispunching;

    void punching()
    {
        if(Input.GetKey(punchkey))
        {
            // calling animation only when key is pressed down
            ispunching= true;
            animator.SetBool("punching", ispunching);
            FindObjectOfType<EnemyController>().EnemyTakeDamage(this.damage);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        punching();
    }
}
