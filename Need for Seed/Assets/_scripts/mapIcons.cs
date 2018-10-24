using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapIcons : MonoBehaviour {

    public GameObject nightmap;
    public GameObject mainmission;
    public GameObject sidemission;

	void Start () {
        if (!Game.current.isNight)
        {
            nightmap.SetActive(false);
            if (Game.current.sideQuest1 == 0)
                sidemission.SetActive(false);
            //else change text
        }
        else
        {
            if (Game.current.mainQuest == 0)
                mainmission.SetActive(false);
            //else change text
        }
	}
}
