using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneDialogueTrigger : MonoBehaviour {

    public Dialogue[] dialogues;
    public GameObject activateNext;
    GameObject deactivate;
    public bool choosing = false, isActive = false, changeCameraPosition = true;
    public Button c1, c2;

    void Start () {
        isActive = true;
        deactivate = this.gameObject;
	}
	
	void Update ()
    {
        if (GetComponent<displayDialogue>().animator.GetBool("isOpen") == true) //dialogue is playing
        {
            if (((Input.GetKeyDown(KeyCode.Return)) || (Input.GetMouseButtonDown(0))) && (!choosing))
            {
                int i = this.GetComponent<displayDialogue>().sentNum;
                this.GetComponent<displayDialogue>().sentNum = i + 1;
                this.GetComponent<displayDialogue>().DisplaySent(i);
            }
        }
        else if ((!choosing) && (isActive)) //dialogue hasn't started
        {
            int dialCount = dialogues.Length;
            this.GetComponent<displayDialogue>().animator.SetBool("isOpen", true);
            this.GetComponent<displayDialogue>().StartDialogue(dialogues[0]);
            isActive = false;
        }
        else if ((!choosing) && (!isActive)) //dialogue ended
        {
            //set camera position
            if (changeCameraPosition)
                GetComponent<moveDialogueCamera>().End();
            //begin 2nd dialogue
            if (activateNext != null)
                activateNext.SetActive(true);
            deactivate.SetActive(false);
        }
    }
}
