using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
        Application.Quit();
		#endif
	}
}
