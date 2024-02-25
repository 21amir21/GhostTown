using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingTafa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerBullet>().toxic = true;
    }
}
