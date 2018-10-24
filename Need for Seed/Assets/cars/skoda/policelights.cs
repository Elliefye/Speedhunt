using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policelights : MonoBehaviour {

	// Use this for initialization
	public GameObject light1;
	public GameObject light2;
	private bool lighton;
	void Start () {
		InvokeRepeating("Blinklights", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Blinklights () {
		if(lighton)
		{
			light1.SetActive(false);
			light2.SetActive(true);
			lighton=false;
		}
		else
		{
			light1.SetActive(true);
			light2.SetActive(false);
			lighton=true;
		}
	}
}
