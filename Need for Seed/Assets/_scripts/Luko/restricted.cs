using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restricted : MonoBehaviour {

	private Renderer renderas;
	public float alpha;
	// Use this for initialization
	void Start () {
		renderas = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Color coloras = Color.white;
		coloras.a = 0.5f-Vector3.Distance(Camera.main.transform.position, transform.position)/alpha;
		renderas.material.SetColor("_TintColor", coloras);
	}
}
