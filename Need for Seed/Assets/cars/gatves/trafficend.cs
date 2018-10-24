using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficend : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "player")
		{
			this.GetComponent<trafficgo>().enabled=false;
		}
	}
}
