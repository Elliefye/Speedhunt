using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene1 : MonoBehaviour {

    public GameObject player;
    public GameObject camera;
    public GameObject cop;
    public GameObject fader;
	// Use this for initialization
	void Start () {
        player.GetComponent<Animator>().enabled = true;
        player.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        player.transform.position = new Vector3(116f, 3.5f, -68.6f);
        player.transform.Rotate(Vector3.zero);
        camera.SetActive(true);
        cop.transform.position = new Vector3(105.9f, 3.6f, -62.1f);
        cop.transform.Rotate(Vector3.up * -90);
        cop.GetComponent<Animator>().SetInteger("Animstate", 3);
        this.transform.parent.gameObject.SetActive(false);
        fader.SetActive(false);
        fader.SetActive(true);
	}
}
