using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PunchingAnim : MonoBehaviour
{

	public KeyCode punchingkey;
	public GameObject boohand;
	private Animator animator;
	private bool punching;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		boohand.SetActive(false);
		punching = true;    
		
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(punchingkey)) { 

			boohand.SetActive(true);
			punching = true;
			//animation
			animator.SetBool("punching",punching);
		
		}
		else if (Input.GetKeyUp(punchingkey))
		{
			boohand.SetActive(false);
			punching=false;
			animator.SetBool("punching", punching);
		}
	}
}
