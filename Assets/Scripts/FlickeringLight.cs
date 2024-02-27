using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
	Light flickeringLight;
	public float rangeBeginning;
	public float rangeEnd;
    // Start is called before the first frame update
    void Start()
    {
		flickeringLight = GetComponent<Light>();
		StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
	{
		while (true)
		{
			yield return new WaitForSeconds(rangeBeginning);
			
			flickeringLight.enabled = !flickeringLight.enabled;
		}
	}
}
