using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setNickname : MonoBehaviour {

	// Use this for initialization
	public InputField name;
	public GameObject inputField;
	public void setNick () {
		if(name.text != "")
		{
			Game.current.name = name.text;
			GetComponent<showDialog>().enabled=true;
			inputField.SetActive(false);
		}
	}
}
