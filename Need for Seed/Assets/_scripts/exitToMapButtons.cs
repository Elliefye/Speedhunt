using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitToMapButtons : MonoBehaviour {

    public GameObject popup;

    public void exit()
    {
        Game.current.isNight = !Game.current.isNight;
        if (!Game.current.isNight)
            Game.current.dayNr++;
    }

    public void cancel()
    {
        popup.SetActive(false);
    }
}
