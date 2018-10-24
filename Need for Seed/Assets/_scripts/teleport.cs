using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    GameObject player;
    public GameObject tracker;
    public GameObject fader;
    public Transform newPlace;
    public int newRoomNr = 0;
    bool checking = false;

	void Start () {
        player = GameObject.FindGameObjectWithTag("player");
	}
	
	void Update () {
        if (GetComponent<changeIcon>().iconChanged && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && (!checking))
        {
            tracker.GetComponent<roomNr>().currentRoom = newRoomNr;
            fader.GetComponent<FadeOut>().roomChange = true;
            checking = true;
        }
        if (!fader.GetComponent<FadeOut>().roomChange && checking)
        {            
            player.transform.position = newPlace.position;
            player.transform.rotation = newPlace.rotation;
            checking = false;
        }           
    }
}
