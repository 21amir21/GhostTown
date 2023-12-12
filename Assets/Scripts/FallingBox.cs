using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    private SpriteRenderer box;
    public Sprite fallBox;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
         box.sprite = fallBox;
        }
    }
}
