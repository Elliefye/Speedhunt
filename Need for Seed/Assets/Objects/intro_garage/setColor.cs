using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour {

	// Use this for initialization
	public Material mat;
	public Color32 coloras;
	void Start () {
		mat.color = coloras;
	}
}
