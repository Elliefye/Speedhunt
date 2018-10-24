using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixFlares : MonoBehaviour {

	// Use this for initialization
	private LensFlare comp;
	void Start () {
		InvokeRepeating("Flareupdate", 0, 0.5f);
		comp = this.GetComponent<LensFlare>();
	}
	
	// Update is called once per frame
	void Flareupdate () {
		comp.brightness = (float) (1-0.002*Vector3.Distance(transform.position, Camera.main.transform.position));
	}
}