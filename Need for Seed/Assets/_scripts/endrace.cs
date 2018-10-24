using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class endrace : MonoBehaviour {

    public GameObject vodtext;
	public GameObject vp;
	public GameObject endracecutscene;
	public GameObject musics;
	public GameObject resulttext;
	public GameObject loadmap;
	void Start()
	{
		if(SceneManager.GetActiveScene().buildIndex == 10)
		{
		endracecutscene.SetActive(true);
		vp.GetComponent<BasicInput>().enabled=false;
		vp.GetComponent<Rigidbody>().velocity = vp.GetComponent<Rigidbody>().velocity/2f;
		vp.GetComponent<VehicleParent>().SetEbrake (1);
		Game.current.rep+=Mathf.RoundToInt(vp.GetComponent<StuntDetect>().score/10);
		Game.current.heat+=2;
		musics.GetComponent<setmusic>().endingMusic();
		resulttext.GetComponent<TextMeshPro>().text = "REPUTATION GAINED: +" + Mathf.RoundToInt(vp.GetComponent<StuntDetect>().score/10) + "\nTOTAL REPUTATION: " + Game.current.rep + "\nHEAT: INCREASED\n\nPRESS MOUSE TO CONTINUE";
		}
	}
	// Use this for initialization
	void OnTriggerEnter(Collider other) {
	if(other.tag == "player")
	{
		endracecutscene.SetActive(true);
		vp.GetComponent<Rigidbody>().velocity = vp.GetComponent<Rigidbody>().velocity/2f;
		vp.GetComponent<VehicleParent>().SetEbrake (1);
		vp.GetComponent<VehicleParent>().SetBrake (1);
		vp.GetComponent<FollowAI>().enabled = false;
		if(Game.current.lost)
		{
			Game.current.lost=false;
			Game.current.cash-=50;
			Game.current.rep-=10;
			Game.current.heat+=2;
			musics.GetComponent<setmusic>().endingMusic();
			vodtext.GetComponent<TextMeshPro>().text = "DEFEAT";
			resulttext.GetComponent<TextMeshPro>().text = "MONEY: -50$\nREPUTATION: -10\nHEAT: INCREASED\n\nPRESS MOUSE TO CONTINUE";
		}
		else
		{
			Game.current.cash+=10;
			Game.current.rep+=30;
			Game.current.heat+=2;
			musics.GetComponent<setmusic>().endingMusic();
			vodtext.GetComponent<TextMeshPro>().text = "VICTORY";
			resulttext.GetComponent<TextMeshPro>().text = "MONEY: +100$\nREPUTATION: +30\nHEAT: INCREASED\n\nPRESS MOUSE TO CONTINUE";
		}
	}
	else
	{
		Game.current.lost=true;
	}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(resulttext.activeSelf && Input.GetMouseButtonDown(0))
		{
            loadmap.SetActive(true);
		}
	}
}
