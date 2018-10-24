using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo : MonoBehaviour {
    private int lighton=0;
	public GameObject light1;
	public GameObject light2;
	// Use this for initialization
	void Start () {
		InvokeRepeating("logolights", 0, 0.15f);
	}
	void logolights()
	{
       if(lighton == 0)
	   {
		   light1.SetActive(true);
		   lighton=1;
	   }
	   else if(lighton == 1)
	   {
		   light1.SetActive(false);
		   lighton=2;
	   }
	   else if(lighton == 2)
	   {
		   light1.SetActive(true);
		   lighton=3;
	   }
	   else if(lighton == 3)
	   {
		   light1.SetActive(false);
		   lighton=4;
	   }
	   else if(lighton == 4)
	   {
		   light2.SetActive(true);
		   lighton=5;
	   }
	   else if(lighton == 5)
	   {
		   light2.SetActive(false);
		   lighton=6;
	   }
	   else if(lighton == 6)
	   {
		   light2.SetActive(true);
		   lighton=7;
	   }
	   else if(lighton == 7)
	   {
		   light2.SetActive(false);
		   lighton=0;
	   }
	}
}
