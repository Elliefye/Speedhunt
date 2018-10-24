using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class setAnimation : MonoBehaviour {

    public string animation;
	// Use this for initialization
	void Start () {
        this.GetComponent<Animator>().Play(animation);
	}
}
