using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().CollectBarrel();
            Debug.Log(FindObjectOfType<PlayerStats>().GetBarrelCount());
            Object.Destroy(gameObject);
        }
    }
}
