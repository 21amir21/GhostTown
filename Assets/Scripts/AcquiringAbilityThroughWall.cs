using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquiringAbilityThroughWall : MonoBehaviour
{

    private void OnDestroy()
    {
        FindObjectOfType<ABThrouhWall>().EnableThroughWall();
    }
}
