﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class showDialog : MonoBehaviour {

    public dialogueSystem dialogManager;
    public string name;
	public string text;
	public Animator talker = null;
	public GameObject player = null;
	public GameObject afterDialog = null;
	public int dialogid;
	// Use this for initialization
	void OnEnable () {
		if(dialogid == 2)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			talker.CrossFadeInFixedTime("prison_sitting2", 1);
		}
		else if(dialogid == 5)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
		}
		else if(dialogid == 11)
		{
			talker.CrossFadeInFixedTime("sad", 1);
			if(Game.current.sideQuest1 == -1)
			{
				text = "Hey, perhaps you have changed your mind? I still need a favour...";
			}
			else if(Game.current.sideQuest1 == 1)
			{
				text = "Oh, I can't thank you enough! Please hurry up...";
				dialogid = -1;
				talker.CrossFadeInFixedTime("happy", 1);
			}
			talker.CrossFadeInFixedTime("talking", 1);
			talker.transform.LookAt(player.transform);
		}
		else if(dialogid == 12 || dialogid == 13 || dialogid == 14)
		{
			player.GetComponent<ThirdPersonUserControl>().enabled=false;
		}
		else if(dialogid == 15)
		{
			talker.CrossFadeInFixedTime("angry", 1);
			talker.transform.LookAt(player.transform);
		}
		if(player)
		{
			player.GetComponent<ThirdPersonUserControl>().enabled=false;
		}
		dialogManager.ShowPlayerDialog(name, text, dialogid);
		dialogManager.talker = talker;
		dialogManager.player = player;
		dialogManager.afterDialogue = afterDialog;
	}
}
