using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipBooHowToPlay : MonoBehaviour
{

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            this.transform.localScale = new Vector3(-(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            timer = 0;
        }
    }
}
