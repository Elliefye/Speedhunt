using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class garageManager : MonoBehaviour {

	public GameObject[] cutscenes;
	public Material carMat;
	public Material wheelMat;
	public GameObject[] wheels;
	public Transform[] carStats;
	public ColorPicker colorPicker;
	public CinemachineVirtualCamera wheelCam;
	public GameObject visualOptions;
	public GameObject pickColor;
	public GameObject pickWheels;
	public GameObject tuneButtons;
	public GameObject fundsBox;
	public Text moneyText;
	public TextMesh multiplier;
	bool performanceTuning=false;
	int whichUpgrade=0;
	Texture rustyTex;
	int whichWheel=0;
	Fader fader;
	// Use this for initialization
	void Start () {
		float multiplierInt = 1f;
		if(carMat.GetTexture("_MainTex") != null)
		{
				multiplierInt+=0.5f;
		}
		if(Game.current.wheelId != 0)
		{
				multiplierInt+=0.5f;
		}
		if(Game.current.carId == 0)
		{
			carStats[0].localScale = new Vector3(0.5f+Game.current.upgrade1/50, 0, 0);
			carStats[1].localScale = new Vector3(0.5f+Game.current.upgrade2/50, 0, 0);
			carStats[2].localScale = new Vector3(4.3f+Game.current.upgrade3/50, 0, 0);
		}
		else if(Game.current.carId == 1 && Game.current.carId == 2 && Game.current.carId == 3)
		{
			carStats[0].localScale = new Vector3(0.43f+Game.current.upgrade1/50, 0, 0);
			carStats[1].localScale = new Vector3(0.3f+Game.current.upgrade2/50, 0, 0);
			carStats[2].localScale = new Vector3(0.3f+Game.current.upgrade3/10, 0, 0);
		}
		multiplier.text = "x"+multiplierInt;
		whichWheel=Game.current.wheelId;
		moneyText.text = "MONEY: $" + Game.current.cash;
		fader = GetComponent<Fader>();
		if(Game.current.color.a < 1f)
		{
			rustyTex = carMat.GetTexture("_MainTex");
		}
		colorPicker.onValueChanged.AddListener(color =>
		{
			ChangeColor();
		});
		if(Game.current.mainQuest == 1)
		{
			cutscenes[1].SetActive(true);
		}
		else
		{
			cutscenes[0].SetActive(true);
		}
	}
	public void ResetChanges()
	{
		carMat.color = Game.current.color;
		if(wheelCam.Priority > 0)
		{
			wheelCam.Priority=0;
			foreach(GameObject wheel in wheels)
			{
				wheel.transform.GetChild(whichWheel).gameObject.SetActive(false);
				wheel.transform.GetChild(Game.current.wheelId).gameObject.SetActive(true);
			}
			whichWheel = Game.current.wheelId;
			wheelMat.color = Game.current.wheelcolor;
			fader.enabled=false;
			fader.enabled=true;
			pickWheels.SetActive(false);
		}
		if(Game.current.color.a < 1f)
		{
			carMat.SetTexture("_MainTex", rustyTex);
		}
		wheelMat.color = Game.current.wheelcolor;
		visualOptions.SetActive(true);
		tuneButtons.SetActive(false);
		pickColor.SetActive(false);
	}
	public void ApplyChanges()
	{
		if(whichUpgrade == 0)
		{
			if(Game.current.wheelId == 0)
			{
				multiplier.text = "x1.5";
			}
			else
			{
				multiplier.text = "x2";
			}
			Game.current.color = colorPicker.CurrentColor;
			pickColor.SetActive(false);
			Game.current.cash-=500;
		}
		else if(whichUpgrade == 1)
		{
			Game.current.wheelcolor = colorPicker.CurrentColor;
			wheelCam.Priority=0;
			fader.enabled=false;
			fader.enabled=true;
			pickColor.SetActive(false);
			Game.current.cash-=100;
		}
		else if(whichUpgrade == 2)
		{
			if(carMat.GetTexture("_MainTex") != null)
			{
				multiplier.text = "x1.5";
			}
			else
			{
				multiplier.text = "x2";
			}
			Game.current.wheelId = whichWheel;
			wheelCam.Priority=0;
			fader.enabled=false;
			fader.enabled=true;
			pickWheels.SetActive(false);
			Game.current.cash-=200;
		}
		moneyText.text = "MONEY: $" + Game.current.cash;
		visualOptions.SetActive(true);
	}
	public void ChangeColor()
	{
		if(whichUpgrade == 0)
		{
			carMat.color = colorPicker.CurrentColor;
		}
		else
		{
			wheelMat.color = colorPicker.CurrentColor;
		}
	}
	public void NextWheel()
	{
		if(whichWheel < 9)
		{
			foreach(GameObject wheel in wheels)
			{
				wheel.transform.GetChild(whichWheel).gameObject.SetActive(false);
				wheel.transform.GetChild(whichWheel+1).gameObject.SetActive(true);
			}
			whichWheel++;
		}
	}
	public void PrevWheel()
	{
		if(whichWheel > 1)
		{
			foreach(GameObject wheel in wheels)
			{
				wheel.transform.GetChild(whichWheel).gameObject.SetActive(false);
				wheel.transform.GetChild(whichWheel-1).gameObject.SetActive(true);
			}
			whichWheel--;
		}
	}
	public void ShowOptions(int whichupgrade)
	{
		whichUpgrade = whichupgrade;
		if(whichUpgrade == 0)
		{
			if(Game.current.cash < 500)
			{
				fundsBox.SetActive(false);
				fundsBox.SetActive(true);
			}
			else
			{
				if(Game.current.color.a < 1f)
				{
					carMat.SetTexture("_MainTex", null);
				}
				visualOptions.SetActive(false);
				tuneButtons.SetActive(true);
				pickColor.SetActive(true);
			}
		}
		else if(whichUpgrade == 1)
		{
			if(Game.current.cash < 100)
			{
				fundsBox.SetActive(false);
				fundsBox.SetActive(true);
			}
			else
			{
				visualOptions.SetActive(false);
				tuneButtons.SetActive(true);
				pickColor.SetActive(true);
				wheelCam.Priority=100;
				fader.enabled=false;
				fader.enabled=true;
			}
		}
		else
		{
			if(Game.current.cash < 200)
			{
				fundsBox.SetActive(false);
				fundsBox.SetActive(true);
			}
			else
			{
				visualOptions.SetActive(false);
				pickWheels.SetActive(true);
				wheelMat.color = new Color(0.7f, 0.7f, 0.7f, 1f);
				tuneButtons.SetActive(true);
				wheelCam.Priority=100;
				fader.enabled=false;
				fader.enabled=true;
			}
		}
	}
}
