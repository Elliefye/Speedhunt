using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class speedometer : MonoBehaviour {
	
	// Update is called once per frame
	VehicleParent vp;	
	public CinemachineVirtualCamera carCamera;
	private CinemachineBasicMultiChannelPerlin vcam;
    public GameObject rpm;
	public Animator reflection;
    public GameObject speed;
    private Text speedtext;

	Motor engine;

	void Start() {
		vcam = carCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		vp = GetComponent<VehicleParent>();
		engine = GetComponentInChildren<Motor>();
        speedtext = speed.GetComponent<Text>();
	}
	void Update () {
		if(reflection)
		{
			reflection.speed = (vp.velMag * 2.23694f * 1.6f)/100;
		}
        rpm.transform.eulerAngles =  new Vector3(0, 0, -4 - 140 * engine.targetPitch);
        speedtext.text = (vp.velMag * 2.23694f * 1.6f).ToString("0");
        vcam.m_FrequencyGain = (vp.velMag * 2.23694f * 1.6f)/100;
		Debug.Log(engine.targetPitch);
    }
}
