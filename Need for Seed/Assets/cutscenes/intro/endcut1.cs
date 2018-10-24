using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endcut1 : MonoBehaviour {

	public GameObject playercar;
	public GameObject copcar;
	public GameObject copcar2;
	public GameObject copcar3;
    public GameObject speedo;

	// Use this for initialization
	void Start () {
        speedo.SetActive(true);
		playercar.GetComponent<FollowAI>().enabled = false;
		playercar.GetComponent<BasicInput>().enabled = true;
		copcar.GetComponent<FollowAI> ().target = playercar.transform;
		copcar2.GetComponent<FollowAI> ().target = playercar.transform;
		copcar3.GetComponent<FollowAI> ().target = playercar.transform;
		playercar.GetComponent<Rigidbody> ().mass = 1;
		//copcar.GetComponent<Rigidbody> ().mass = 5;

	}
}
