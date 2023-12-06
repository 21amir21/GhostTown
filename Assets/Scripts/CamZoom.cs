using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamZoom : MonoBehaviour
{
    private Camera Cam; //will use this to GetComponent
    public float ZoomSpeed; //Speed of zooming in or out
    public KeyCode ZbuHon; //Letter Z in Keyboard

     // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>(); //initilization for Cam
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetKey(ZbuHon)) //If we press Z
        {
            //htgyer el orthographicSize bta3 el camera ( Size el camera ely f unity hya el orthographicSize f el script )
 
            //(in param. awel 7agh what is the value right now ' ely hwa 7 ', target value, speed)

        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 8, Time.deltaTime *ZoomSpeed);
        }
        else //eza shelt edyy mn el Z button
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 6, Time.deltaTime *ZoomSpeed);
        }
    }
}