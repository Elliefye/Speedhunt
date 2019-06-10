using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursuit : MonoBehaviour {

	// Use this for initialization
	public VehicleParent vp;
	public GameObject fader;
	private int catchcount=0;
	// Update is called once per frame
	void Start()
	{
		InvokeRepeating("CheckPursuit", 1f, 1f);
	}
	void CheckPursuit () {
		if(vp.velMag * 2.23694f * 1.6f < 5f)
		{
			catchcount+=1;
		}
		else
		{
			catchcount-=1;
			if(catchcount < 0)
			{
				catchcount=0;
			}
		}
		if(catchcount > 5)
		{
			fader.SetActive(true);
		}
	}
}
