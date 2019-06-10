using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class setAnimation : MonoBehaviour {

    public string[] animation;
	// Use this for initialization
	void OnEnable () {
		foreach(string animas in animation)
		{
			Debug.Log(animas);
			this.GetComponent<Animator>().Play(animas);
		}
	}
}
