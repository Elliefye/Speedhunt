using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioClip sound;
	// Use this for initialization
	void OnEnable () {
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
