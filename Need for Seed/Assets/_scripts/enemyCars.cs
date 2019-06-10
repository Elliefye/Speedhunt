using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro; 

public class enemyCars : MonoBehaviour {

/*	public GameObject[] suspensions;
	public GameObject[] lights;
	public GameObject motor;
	private GasMotor variklis;
	public GameObject wheel1;
	public GameObject wheel2;
	public GameObject wheel3;
	public GameObject wheel4;
	public GameObject licenseplate;
	public GameObject[] boostParticles;
	public Material carmat;
	//public 
	public string whichName = "Lewsar";
	void Start () {
		variklis = motor.GetComponent<GasMotor>();
		int whichCar;
		if(Game.current.mainQuest < 3)
		{
			whichCar = Random.Range(1, 4);
		}
		else
		{
			whichCar = 0;
		}
		Color32 carcolor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255));
		carmat.SetColor("_Color", carcolor);
		foreach (Transform child in transform) {
			if (whichCar.ToString () == child.name) {
                child.gameObject.SetActive(true);
				foreach (Transform ratas in wheel1.transform) 
				{
                   		if("wheel" + (whichCar+1).ToString () == ratas.gameObject.name)
				   		{
					   		ratas.gameObject.SetActive(true);
							break;
				   		}
				}
				foreach (Transform ratas in wheel2.transform) 
				{
                   		if("wheel" + (whichCar+1).ToString () == ratas.name)
				   		{
					   		ratas.gameObject.SetActive(true);
							break;
				   		}
				}
				foreach (Transform ratas in wheel3.transform) 
				{
                   		if("wheel" + (whichCar+1).ToString () == ratas.name)
				   		{
					   		ratas.gameObject.SetActive(true);
							break;
				   		}
				}
				foreach (Transform ratas in wheel4.transform) 
				{
                   		if("wheel" + (whichCar+1).ToString () == ratas.name)
				   		{
					   		ratas.gameObject.SetActive(true);
							break;
				   		}
				}
				licenseplate.GetComponent<TextMeshPro>().text = whichName;
				if(whichCar == 0) //Nissan
				{
					variklis.torqueCurve.AddKey(5f, 0);
					variklis.power = 0.4f;
		            variklis.GetMaxRPM();
					wheel1.transform.localScale = new Vector3(0.8f, 0.8f, 1);
					wheel2.transform.localScale = new Vector3(0.8f, 0.8f, 1);
					wheel3.transform.localScale = new Vector3(0.8f, 0.8f, 1);
					wheel4.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                    suspensions[0].transform.localPosition = new Vector3(-0.82f, -0.269f, 1.56f);
					suspensions[1].transform.localPosition = new Vector3(0.86f, -0.269f, 1.56f);
					suspensions[2].transform.localPosition = new Vector3(-0.82f, -0.2690f, -1.48f);
					suspensions[3].transform.localPosition = new Vector3(0.86f, -0.2690f, -1.48f);
					lights[0].transform.localPosition = new Vector3(-0.72f, 0.36f, -2.44f);
					lights[1].transform.localPosition = new Vector3(0.72f, 0.36f, -2.46f);
					lights[2].transform.localPosition = new Vector3(0, 0.466f, -2.495f);
					lights[3].transform.localPosition = new Vector3(-0.66f, 0.12f, 2.26f);
					lights[4].transform.localPosition = new Vector3(0.65f, 0.12f, 2.26f);
					lights[5].transform.localPosition = new Vector3(0.26f, 0.02f, -2.6f);
					lights[6].transform.localPosition = new Vector3(0.32f, 0.02f, -2.6f);
					licenseplate.transform.localPosition = new Vector3(0.32f, 0.34f, -2.54f);
					boostParticles[0].transform.localPosition = new Vector3(-0.435f, -0.223f, -2.753f); //bpl
					boostParticles[1].transform.localPosition = new Vector3(-0.435f, -0.223f, -2.753f); //bpr
				}
				else if(whichCar == 1) //BMW
				{
					variklis.torqueCurve.AddKey(4.3f, 1);
					variklis.power = 0.3f;
		            variklis.GetMaxRPM();
					wheel1.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel2.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel3.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel4.transform.localScale = new Vector3(0.65f, 0.65f, 1);
                    suspensions[0].transform.localPosition = new Vector3(-0.76f, -0.27f, 1.63f); //FL
					suspensions[1].transform.localPosition = new Vector3(0.78f, -0.27f, 1.62f); //FR
					suspensions[2].transform.localPosition = new Vector3(-0.76f, -0.269f, -1.23f); //RL
					suspensions[3].transform.localPosition = new Vector3(0.78f, -0.269f, -1.23f); //RR
					lights[0].transform.localPosition = new Vector3(-0.6783f, 0.132f, -2.15f); //bl
					lights[1].transform.localPosition = new Vector3(0.699f, 0.114f, -2.14f); //br
					lights[2].transform.localPosition = new Vector3(0, 0.13f, -1.52f); //bsh
					lights[3].transform.localPosition = new Vector3(-0.644f, 0.011f, 2.23f); //hl
					lights[4].transform.localPosition = new Vector3(0.65f, 0, 2.256f); //hr
					lights[5].transform.localPosition = new Vector3(0.56f, 0.188f, -2.157f); //rr
					lights[6].transform.localPosition = new Vector3(-0.557f, 0.188f, -2.16f); //rl
					licenseplate.transform.localPosition = new Vector3(0.303f, 0.52f, -2.18f);
					boostParticles[0].transform.localPosition = new Vector3(-0.584f, -0.326f, -2.411f); //bpl
					boostParticles[1].transform.localPosition = new Vector3(-0.506f, -0.313f, -2.385f); //bpr
				}
				else if(whichCar == 2) //VW
				{
					variklis.torqueCurve.AddKey(4.3f, 1);
					variklis.power = 0.3f;
		            variklis.GetMaxRPM();
					wheel1.transform.localScale = new Vector3(0.7f, 0.7f, 1);
					wheel2.transform.localScale = new Vector3(0.7f, 0.7f, 1);
					wheel3.transform.localScale = new Vector3(0.7f, 0.7f, 1);
					wheel4.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                    suspensions[0].transform.localPosition = new Vector3(-0.76f, -0.27f, 1.28f); //FL
					suspensions[1].transform.localPosition = new Vector3(0.78f, -0.27f, 1.28f); //FR
					suspensions[2].transform.localPosition = new Vector3(-0.76f, -0.269f, -1.48f); //RL
					suspensions[3].transform.localPosition = new Vector3(0.78f, -0.269f, -1.48f); //RR
					lights[0].transform.localPosition = new Vector3(-0.649f, 0.25f, -2.246f); //bl
					lights[1].transform.localPosition = new Vector3(0.68f, 0.227f, -2.194f); //br
					lights[2].transform.localPosition = new Vector3(0.084f, 0.102f, -1.082f); //bsh
					lights[3].transform.localPosition = new Vector3(-0.691f, 0.117f, 1.999f); //hl
					lights[4].transform.localPosition = new Vector3(0.698f, 0.113f, 1.993f); //hr
					lights[5].transform.localPosition = new Vector3(0.769f, 0.33f, -2.127f); //rr
					lights[6].transform.localPosition = new Vector3(-0.76f, 0.34f, -2.132f); //rl
					licenseplate.transform.localPosition = new Vector3(0.301f, 0.347f, -2.373f);
					boostParticles[0].transform.localPosition = new Vector3(-0.337f, -0.296f, -2.517f); //bpl
					boostParticles[1].transform.localPosition = new Vector3(-0.315f, -0.388f, -2.304f); //bpr
				}
				else if(whichCar == 3) //CIVIC
				{
					variklis.torqueCurve.AddKey(4.3f, 1);
					variklis.power = 0.3f;
		            variklis.GetMaxRPM();
					wheel1.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel2.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel3.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel4.transform.localScale = new Vector3(0.65f, 0.65f, 1);
                    suspensions[0].transform.localPosition = new Vector3(-0.76f, -0.27f, 1.35f); //FL
					suspensions[1].transform.localPosition = new Vector3(0.78f, -0.27f, 1.35f); //FR
					suspensions[2].transform.localPosition = new Vector3(-0.76f, -0.269f, -1.48f); //RL
					suspensions[3].transform.localPosition = new Vector3(0.78f, -0.269f, -1.48f); //RR
					lights[0].transform.localPosition = new Vector3(-0.77f, 0.19f, -2.08f); //bl
					lights[1].transform.localPosition = new Vector3(0.77f, 0.19f, -2.08f); //br
					lights[2].transform.localPosition = new Vector3(0.084f, 0.102f, -1.082f); //bsh
					lights[3].transform.localPosition = new Vector3(-0.74f, 0.06f, 1.9f); //hl
					lights[4].transform.localPosition = new Vector3(0.74f, 0.06f, 1.9f); //hr
					lights[5].transform.localPosition = new Vector3(0.53f, 0.26f, -2.13f); //rr
					lights[6].transform.localPosition = new Vector3(-0.53f, 0.26f, -2.13f); //rl
					licenseplate.transform.localPosition = new Vector3(0.301f, 0.61f, -2.12f);
					boostParticles[0].transform.localPosition = new Vector3(-0.44f, -0.4f, -2.35f); //bpl
					boostParticles[1].transform.localPosition = new Vector3(0.44f, -0.4f, -2.35f); //bpr
				}
				else if(whichCar == 4) //CELICA
				{
					variklis.torqueCurve.AddKey(4.8f, 1);
					variklis.power = 0.4f;
		            variklis.GetMaxRPM();
					wheel1.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel2.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel3.transform.localScale = new Vector3(0.65f, 0.65f, 1);
					wheel4.transform.localScale = new Vector3(0.65f, 0.65f, 1);
                    suspensions[0].transform.localPosition = new Vector3(-0.76f, -0.27f, 1.52f); //FL
					suspensions[1].transform.localPosition = new Vector3(0.78f, -0.27f, 1.52f); //FR
					suspensions[2].transform.localPosition = new Vector3(-0.76f, -0.27f, -1.23f); //RL
					suspensions[3].transform.localPosition = new Vector3(0.78f, -0.27f, -1.23f); //RR
					lights[0].transform.localPosition = new Vector3(-0.63f, 0.12f, -2.02f); //bl
					lights[1].transform.localPosition = new Vector3(0.63f, 0.12f, -2.02f); //br
					lights[2].transform.localPosition = new Vector3(0.01f, 0.32f, -2.05f); //bsh
					lights[3].transform.localPosition = new Vector3(-0.74f, -0.01f, 2.35f); //hl
					lights[4].transform.localPosition = new Vector3(0.74f, -0.01f, 2.35f); //hr
					lights[5].transform.localPosition = new Vector3(0.5f, 0.12f, -2.04f); //rr
					lights[6].transform.localPosition = new Vector3(-0.5f, 0.12f, -2.04f); //rl
					licenseplate.transform.localPosition = new Vector3(0.301f, 0.49f, -2f);
					boostParticles[0].transform.localPosition = new Vector3(-0.5f, -0.37f, -2.17f); //bpl
					boostParticles[1].transform.localPosition = new Vector3(0.5f, -0.37f, -2.17f); //bpr
				}
			}
		}
	}*/
}
