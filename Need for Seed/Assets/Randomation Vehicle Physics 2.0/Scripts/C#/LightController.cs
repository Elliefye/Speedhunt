using UnityEngine;
using System.Collections;
[RequireComponent(typeof(VehicleParent))]
[DisallowMultipleComponent]
[AddComponentMenu("RVP/C#/Effects/Light Controller", 2)]

//Class for controlling vehicle lights
public class LightController : MonoBehaviour
{
	VehicleParent vp;
	public GameObject[] brakeLights;
	public GameObject[] reverseLights;

	 public Transmission transmission;
        GearboxTransmission gearTrans;
	private Light light1;
	private Light light2;

	void Start()
	{
		vp = GetComponent<VehicleParent>();
		light1 = brakeLights[0].GetComponent<Light>();
		light2 = brakeLights[1].GetComponent<Light>();
		gearTrans = transmission as GearboxTransmission;
	}

	void FixedUpdate()
	{
		if((vp.burnout > 0 && vp.brakeInput > 0) || ((vp.brakeInput > 0 && vp.localVelocity.z > 1) || (vp.accelInput > 0 && vp.localVelocity.z < -1)))
		{
				light1.intensity = 6f;
				light2.intensity = 6f;
				brakeLights[2].SetActive(true);
		}
		else
		{
			light1.intensity = 4f;
			light2.intensity = 4f;
			brakeLights[2].SetActive(false);
		}
		if(gearTrans.curGearRatio < 0)
		{
           reverseLights[0].SetActive(true);
		   reverseLights[1].SetActive(true);
		}
		else
		{
		   reverseLights[0].SetActive(false);
		   reverseLights[1].SetActive(false);
		}
	}
}
	