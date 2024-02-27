using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
	public TextMeshProUGUI dialogueText;
	public GameObject dialoguePanel;
	public DialogueLines lines;
	public float textSpeed;
	private int index;

	// Start is called before the first frame update
	void Start()
	{
		dialogueText.text = string.Empty;
		StartDialogue();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			button();
		}
	}

	void StartDialogue()
	{
		index = 0;
		StartCoroutine(TypeLine());
	}

	IEnumerator TypeLine()
	{
		foreach (char c in lines.lines[index].ToCharArray()) {
			dialogueText.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
	}

	void NextLine()
	{
		if (index < lines.lines.Length - 1)
		{
			index++;
			dialogueText.text = string.Empty;
			StartCoroutine(TypeLine());
		}
		else
		{
			dialoguePanel.SetActive(false);
		}
	}

	public void button()
	{
		if (dialogueText.text == lines.lines[index])
		{
			NextLine();
		}
		else
		{
			StopAllCoroutines();
			dialogueText.text = lines.lines[index];
		}
	}
}
