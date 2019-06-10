using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookathim : MonoBehaviour {

	// Use this for initialization
	public Transform leye;
	public Transform reye;
	
	// Update is called once per frame
	void LateUpdate () {
		leye.LookAt(Camera.main.transform);
		reye.LookAt(Camera.main.transform);
		//Vector3 rot = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
		//transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
	}
	void OnDisable ()
	{
		leye.rotation = Quaternion.Euler(0f, 0f, 0f);
		reye.rotation = Quaternion.Euler(0f, 0f, 0f);
	}
}
