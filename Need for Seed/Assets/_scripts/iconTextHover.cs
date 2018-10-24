using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconTextHover : MonoBehaviour {

    public RawImage self;
    public RawImage textbg;
    public Text text;
    public bool mainquest = false;
    public bool sidequest = false;

	void Start () {
        textbg.gameObject.SetActive(false);

 //       if (sidequest)
  //          text.text = missionNames.sideQuests[Game.current.sideQuest - 1];

        if (mainquest)
            text.text += (10-Game.current.mainQuest+1).ToString();
	}

    public void activate()
    {
        self.color = new Color32(255, 255, 255, 255);
        textbg.gameObject.SetActive(true);
    }

    public void deactivate()
    {
        self.color = new Color32(165, 165, 165, 238);
        textbg.gameObject.SetActive(false);
    }
}
