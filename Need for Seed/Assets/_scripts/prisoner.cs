using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prisoner : MonoBehaviour {

    public Button choice1;
    public Button choice2;
    bool choiceMade = false;
    bool talkingToPrisoner = false;

	void Start () {
		choice1.onClick.AddListener(delegate { Choice1(); });
        choice2.onClick.AddListener(delegate { Choice2(); });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
            talkingToPrisoner = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
            talkingToPrisoner = false;
    }

    void Choice1()
    {
        if (!choiceMade && talkingToPrisoner)
        {
            GetComponent<Animator>().SetInteger("helped", 1);
            //Game.current.sideQuest = 1;
            Dialogue[] d = new Dialogue[1];
            d[0] = new Dialogue();
            d[0].name = "Prisoner";
            d[0].sentences = new string[] { "Please, hurry up! I haven't seen my daughter in five years!" };
            GetComponent<dialogueTrigger>().dialogues = d;
            GetComponent<displayDialogue>().dialCount = 1;
            choiceMade = true;
        }
    }

    void Choice2()
    {
        if (!choiceMade && talkingToPrisoner)
        {
            GetComponent<Animator>().SetInteger("helped", 2);
            Dialogue[] d = new Dialogue[1];
            d[0] = new Dialogue();
            d[0].name = "Prisoner";
            d[0].sentences = new string[] { "I hope you rot in hell. I haven't seen my daughter in five years!" };
            GetComponent<dialogueTrigger>().dialogues = d;
            GetComponent<displayDialogue>().dialCount = 1;
            choiceMade = true;
        }
    }
}
