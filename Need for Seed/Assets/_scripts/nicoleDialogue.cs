using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nicoleDialogue : MonoBehaviour {

	void Awake () {
        Dialogue[] dial = new Dialogue[0];

        if(Game.current.racedCount == 0)
        {
            dial = new Dialogue[3];

            dial[0].name = "Nicole";
            dial[0].sentences = new string[] { "", "", "" };
        }

        GetComponent<dialogueTrigger>().dialogues = dial;
	}
}
