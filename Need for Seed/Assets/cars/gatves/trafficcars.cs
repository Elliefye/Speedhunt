using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficcars : MonoBehaviour {

	public GameObject[] traffic_cars;
	private int traffic_car;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "player")
		{
			traffic_car = Random.Range(0, traffic_cars.Length);
 			//traffic_cars[traffic_car].gameObject.GetComponent<Animator>().enabled = true;
			 traffic_cars[traffic_car].gameObject.SetActive(true);
		}
	}
}
