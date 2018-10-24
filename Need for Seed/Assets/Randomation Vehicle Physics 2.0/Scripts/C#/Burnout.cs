using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnout : MonoBehaviour {

	VehicleParent vp;
    public float angle = 1;
	void Start () {
		vp = GetComponent<VehicleParent>();
		vp.SetAccel (1);
		vp.SetBrake (1);
		vp.SetSteer (angle);
	}
    private void OnDisable()
    {
        vp.SetAccel(0);
        vp.SetBrake(0);
        vp.SetSteer(0);
    }
}
