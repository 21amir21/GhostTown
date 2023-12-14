using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentPolicescene2 : MonoBehaviour
{
    private SpriteRenderer policevent;
    public Sprite policeopenvent;
    // Start is called before the first frame update
    void Start()
    {
        policevent = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            policevent.sprite = policeopenvent;
        }
    }
}
