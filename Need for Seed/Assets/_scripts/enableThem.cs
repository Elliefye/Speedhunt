using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableThem : MonoBehaviour {

	// Use this for initialization
	public GameObject[] toenable = new GameObject[0];
	public GameObject[] todisable = new GameObject[0];
	void Start () {
		foreach (GameObject objectas in todisable) {
			objectas.active = false;
		}
		foreach (GameObject objectas in toenable) {
			objectas.active = true;
		}
	}
}
