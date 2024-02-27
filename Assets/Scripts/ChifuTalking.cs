using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueInfoBooChifu
{
    public string dialogue;
    public Sprite image;
}

public class ChifuTalking : MonoBehaviour
{
    public GameObject dialoguePanel;
   
    public TMP_Text dialogueText;
    public Image imageDisplay;
    public float wordSpeed;
    public bool playerIsClose;

    public List<DialogueInfo> dialogueInfoList;
    private int index;

    public GameObject continueButton;

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.P) )
		{
			NextLine();
		}
	}

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogueInfoList[index].dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
		
        if (index < dialogueInfoList.Count - 1)
        {
            index++;
            dialogueText.text = "";
            imageDisplay.sprite = dialogueInfoList[index].image;
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            if (playerIsClose)
            {
                if (dialoguePanel.activeInHierarchy)
                {
                    ZeroText();

                }
                else
                {
                    dialoguePanel.SetActive(true);

                    imageDisplay.sprite = dialogueInfoList[index].image;
                    StartCoroutine(Typing());
                }
            }

            if (dialogueText.text == dialogueInfoList[index].dialogue)
            {
                continueButton.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
            
        }
    }
}