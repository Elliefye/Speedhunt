using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    public GameObject[] people = new GameObject[5];
    public bool isActive = false, playerNear = false, choosing = false;
    public Button c1, c2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            playerNear = true;

            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] != null)
                    people[i].GetComponent<dialogueTrigger>().enabled = false;
                else break;
            }

            c1.GetComponent<displayDialogue>().trigger = gameObject;
            c2.GetComponent<displayDialogue>().trigger = gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            playerNear = false;

            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] != null)
                    people[i].GetComponent<dialogueTrigger>().enabled = true;
                else break;
            }
        }
    }

    private void Update()
    {
        if (GetComponentInChildren<changeIcon>().iconChanged)
            isActive = true;
        else isActive = false;

        if (GetComponent<displayDialogue>().animator.GetBool("isOpen") == true)
        {
            if (((Input.GetKeyDown(KeyCode.Return)) || (Input.GetMouseButtonDown(0))) && (!choosing))
            {
                int i = this.GetComponent<displayDialogue>().sentNum;
                this.GetComponent<displayDialogue>().sentNum = i + 1;
                this.GetComponent<displayDialogue>().DisplaySent(i);
            }
        }
		else if (((Input.GetKeyDown(KeyCode.Return) || (Input.GetMouseButtonDown(0)))) && (isActive == true) && (playerNear == true) && (!choosing))
        {
            int dialCount = dialogues.Length;
            this.GetComponent<displayDialogue>().animator.SetBool("isOpen", true);
            this.GetComponent<displayDialogue>().StartDialogue(dialogues[0]);
        }
    }
}
