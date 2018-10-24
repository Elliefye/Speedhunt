using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBurnout : MonoBehaviour {

    public GameObject car;
	// Use this for initialization
	void Start () {
        car.GetComponent<Burnout>().enabled = true;
	}
}
