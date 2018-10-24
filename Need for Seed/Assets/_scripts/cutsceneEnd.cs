using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutsceneEnd : MonoBehaviour {

	public GameObject scriptas;
	// Use this for initialization
	private void Update()
	{
		if (GetComponent<PlayableDirector> ().state != PlayState.Playing) {
			scriptas.active = false;
			scriptas.active = true;
		}
	}
}
