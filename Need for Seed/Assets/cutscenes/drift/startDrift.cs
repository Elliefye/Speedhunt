using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDrift : MonoBehaviour {

    public GameObject car;
    public GameObject speedo;
    public GameObject driftScore;
	// Use this for initialization
	void Start () {
        speedo.SetActive(true);
        driftScore.SetActive(true);
        car.GetComponent<BasicInput>().enabled = true;
        car.GetComponent<Burnout>().enabled = false;
	}
}
