using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public TextMeshProUGUI dialogText;
	public string[] dialogLines;
	public float typingSpeed = 0.05f;
	public GameObject pannel;
	private int currentLine = 0;
	private bool isTyping = false;

	void Start()
	{
		StartCoroutine(StartDialog());
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
		{
			pannel.SetActive(true);
			NextLine();
		}
	}

	IEnumerator StartDialog()
	{
		foreach (char letter in dialogLines[currentLine].ToCharArray())
		{
			dialogText.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
		isTyping = false;
	}

	void NextLine()
	{
		if (currentLine < dialogLines.Length - 1)
		{
			currentLine++;
			dialogText.text = "";
			StartCoroutine(StartDialog());
		}
		else
		{
			// End of dialog
			EndDialog();
		}
	}

	void EndDialog()
	{
		// You can add any additional logic here when the dialog ends
		pannel.SetActive(false) ;
		Debug.Log("End of dialog");
	}
}
