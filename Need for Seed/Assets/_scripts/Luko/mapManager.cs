using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapManager : MonoBehaviour {

	// Use this for initialization
	public GameObject policeicon;
	public GameObject garageicon;
	public Text moneytext;
	public Text heattext;
	public Text reptext;
	public Texture daytex;
	public Texture nighttex;
	public GameObject[] races;
	public GameObject[] sidequests;
	public GameObject[] smses;
	void Start () {
		if(Game.current.isNight)
		{
		   Game.current.isNight=false;
		   races[0].SetActive(true);
		   races[1].SetActive(true);
           this.GetComponent<Renderer>().material.SetTexture("_MainTex", nighttex);
		   if(Game.current.mainQuest == 3)
		   {
			   races[2].SetActive(true);
		   }
		}
		else
		{
			if(Game.current.sideQuest1 == 1)
			{
				sidequests[0].SetActive(true);
			}
			Game.current.isNight=true;
			policeicon.SetActive(true);
			garageicon.SetActive(true);
			this.GetComponent<Renderer>().material.SetTexture("_MainTex", daytex);
		}
		/*          SHOWING SMS'ES                      */
		if(Game.current.mainQuest == 0)//Showing Nicole's SMS
		{
			smses[0].SetActive(true);
			Game.current.mainQuest++;
		}
		else if(Game.current.mainQuest == 1)//Showing Bob's SMS
		{
			smses[1].SetActive(true);
			Game.current.mainQuest++;
		}
		moneytext.text = "MONEY: $" + Game.current.cash;
		reptext.text = "REPUTATION: " + Game.current.rep;
		if(Game.current.heat >= 10)
		{
			heattext.text = "HEAT: <color=#E80022>DANGEROUS</color>";
		}
		else if(Game.current.heat >= 5)
		{
			heattext.text = "HEAT: SUSPICIOUS";
		}
		else
		{
			heattext.text = "HEAT: <color=#1082DA>INDIFFERENT</color>";
		}
	}
}
