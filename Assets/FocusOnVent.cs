using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnVent : MonoBehaviour
{


    public Transform vent;
    private float timer = 0.0f;
    public float Cameraspeed;
    public float minX, maxX;
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = true;
        FindObjectOfType<CameraFollowPri>().enabled = false;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer < 2.5f)
        {
            if (vent != null)
            {
                Vector2 newCamPosition = Vector2.Lerp(transform.position, vent.position, Cameraspeed * Time.deltaTime);
                float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
                float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
                transform.position = new Vector3(ClampX, ClampY, -10f);
            }
        }
        else
        {
            this.enabled = false;
            FindObjectOfType<CameraFollowPri>().enabled = true;
            FindObjectOfType<PlayerMovement>().enabled = true;
        }
    }
    public void VentCameraEnable()
    {
        this.enabled = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
    }
}
