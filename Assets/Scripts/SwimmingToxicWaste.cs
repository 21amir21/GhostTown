using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingToxicWaste : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isToxicWaste;
    private bool isSwimming;
    [SerializeField] Rigidbody2D rb;



    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isToxicWaste && Mathf.Abs(vertical) > 0f)
        {
            isSwimming = true;

        }

    }

    private void FixedUpdate()
    {
        if (isSwimming)
        {
            rb.gravityScale = 0.2f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f; // return player's gravity back to 1 // the normal
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ToxicWaste"))
        {
            isToxicWaste = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ToxicWaste"))
        {
            isToxicWaste = false;
            isSwimming = false;
			rb.AddForce(new Vector2(0, 50));
        }
    }
}
