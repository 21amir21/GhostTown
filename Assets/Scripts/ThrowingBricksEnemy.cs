using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBricksEnemy : MonoBehaviour

{

    public Transform firePoint;
    public GameObject brickLeft;
	public GameObject brickRight;
    private  float duration = 2f;
    private float timer = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            ThrowBrick();
            timer = 0f;
        }
    }

    public void ThrowBrick()
    {
		if (transform.localScale.x > 0)
		{
			Instantiate(brickRight, firePoint.position, firePoint.rotation);
		}
		else
		{
			Instantiate(brickLeft, firePoint.position, firePoint.rotation);
		}
    }
}
