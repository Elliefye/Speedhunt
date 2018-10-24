using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayDialogue : MonoBehaviour
{
    public bool buttonTrigger = false, cutscene = false;
	public string[] sentences = new string[0];
	public Image icon_sprite;
	public Text nameText, dialogueText;
	public Animator animator, playerTalk;
	public int sentNum = 0, dialCount = 0, currentDial = 0, j;
    string playerName;
    public bool rotateTrigger = false;
    Quaternion defaultPos;
    public Button choice1, choice2;
    public GameObject trigger;

    private void Start()
	{
        if(!buttonTrigger)
        {
            defaultPos = transform.rotation;
            if(cutscene)
                dialCount = GetComponent<cutsceneDialogueTrigger>().dialogues.Length;
            else dialCount = GetComponent<dialogueTrigger>().dialogues.Length;
            playerName = Game.current.name;
        }      
    }

    public void StartDialogue(Dialogue dialogue)
	{
        if (dialogue.name == "-")
        {
            endDialogue();
            return;
        }

        if (rotateTrigger)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("player").transform);
        }

		sentences = new string[dialogue.sentences.Length];
		
		sentNum = 0;
		if (dialogue.name != "*")
			nameText.text = dialogue.name;
		else nameText.text = playerName;
		j = 0;

		foreach (string sentence in dialogue.sentences)
		{
			sentences[j] = sentence;
			j++;
		}

        if (playerTalk != null)
            playerTalk.SetBool("speaking", true);

        if (dialogue.name == "#")
        {
            nameText.text = playerName;
            displayChoices(dialogue.sentences);
        }
        else DisplaySent(0);

	}

	public void DisplaySent(int number)
	{
        if (number == 0)
			sentNum++;
		if (j > number)
		{
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentences[number]));
		}
		else
		{
			currentDial++;
			if (dialCount > currentDial)
            {
                if(cutscene)
                    StartDialogue(GetComponent<cutsceneDialogueTrigger>().dialogues[currentDial]);
                else StartDialogue(GetComponent<dialogueTrigger>().dialogues[currentDial]);
            }				
			else
				endDialogue();
		}
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			if(letter != '*')
			{
				dialogueText.text += letter;
				yield return null;
			} 
			else
			{
				foreach (char l in playerName)
				{
					dialogueText.text += l;
					yield return null;
				}

			}
		}
	}

	void endDialogue()
	{
        if (playerTalk != null)
            playerTalk.SetBool("speaking", false);

        animator.SetBool("isOpen", false);
        j = 0;
		sentNum = 0;
		currentDial = 0;		

        if(rotateTrigger)
            transform.rotation = defaultPos;
	}

    public void displayChoices(string[] choices)
    {
        GetComponent<dialogueTrigger>().choosing = true;
        StopAllCoroutines();
        dialogueText.text = "";
        choice1.GetComponentInChildren<Text>().text = choices[0];
        choice2.GetComponentInChildren<Text>().text = choices[1];
        choice1.gameObject.SetActive(true);
        choice2.gameObject.SetActive(true);
    }

    public void choice1chosen()
    {
        var t_trig = trigger.GetComponent<dialogueTrigger>();
        var t_display = trigger.GetComponent<displayDialogue>();
        t_display.currentDial++;
        t_trig.choosing = false;
        t_display.StartDialogue(t_trig.dialogues[t_display.currentDial]);
        choice2.gameObject.SetActive(false);
        choice1.gameObject.SetActive(false);
    }

    public void choice2chosen()
    {
        var t_trig = trigger.GetComponent<dialogueTrigger>();
        var t_display = trigger.GetComponent<displayDialogue>();
        t_display.currentDial += 3; //this gives for 1 dialogue after the choice
        t_trig.choosing = false;
        t_display.StartDialogue(t_trig.dialogues[t_display.currentDial]);
        choice1.gameObject.SetActive(false);
        choice2.gameObject.SetActive(false);
    }

}