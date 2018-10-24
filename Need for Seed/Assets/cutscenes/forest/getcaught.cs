using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class getcaught : MonoBehaviour {

    public GameObject camera;
    public GameObject player;
    public GameObject cop;
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if(other.tag == "player")
        {
            camera.transform.LookAt(cop.transform);
            camera.GetComponent<SmoothMouseLook>().enabled = false;
            player.GetComponent<ThirdPersonCharacter>().enabled=false;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<showDialog>().enabled = true;
        }
	}
}
