using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityStandardAssets.Characters.ThirdPerson;

public class dialogueSystem : MonoBehaviour {

	public Text nameText, dialogueText;
	public Animator animator;
	public GameObject choice1, choice2, choice3, choice4;
	private int dialogID;
	bool choosing=false;
    public GameObject afterDialogue;
	public Animator talker;
	public GameObject player;
    private bool typing = false;
	void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("dialogueboxopen") && !choosing && Input.GetMouseButtonDown(0))
		{
			if(typing)
			{
				typing=false;
			}
			else
			{
				OnDialogResponse();
			}
		}
    }
	void OnDialogResponse()
	{
		if (dialogID == -1) {
			animator.SetBool ("isOpen", false);
			Game.current.checking = false;
			if(talker)
			{
				talker.CrossFadeInFixedTime("faceIdle", 1);
				talker.GetComponent<lookathim>().enabled = false;
			}
			if(player) 
			{
				lookathim eyescript = talker.GetComponent<lookathim>();
				if(eyescript)
				{
					eyescript.enabled=false;
				}
				player.GetComponent<ThirdPersonUserControl>().enabled=true;
			}
            if(afterDialogue)
            {
                afterDialogue.SetActive(true);
            }
		} 
		else if (dialogID == 1) {
            Camera.main.gameObject.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.transform.position = new Vector3(146.9353f, 29.38417f, 1473.751f);
            Camera.main.gameObject.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.transform.rotation = Quaternion.Euler(2.063f, -43.659f, 0f);
            ShowPlayerDialog("Second cop", "The fucker must have set off into the forest and it's pitch black. I can't see shit!", -1);
		}
		else if(dialogID == 2)
		{
			ShowPlayerDialog("Nicole", "My name is Nicole Perkins. I am an FBI agent appointed on a special case which involves street racing activities and even more.", 3);
		}
		else if(dialogID == 3)
		{
			ShowPlayerDialog("Nicole", "The reason why I'm here is that we need someone with the best driving skills and crime history to be our tool in this investigation. Lucky for you the main candidate for this mission is you. The question is, do you want to cooperate?", 4);
		}
		else if(dialogID == 4)
		{
		   talker.CrossFadeInFixedTime("faceidle", 1);
           ShowPlayerChoices("What's in it for me?", "Why me?", "What will I have to do?", "AGREE", 4);
		}
		else if(dialogID == 5)
		{
			ShowPlayerDialog("Nicole", "The gang organizes illegal street races throughout the city with large prizes and attracts lots of the local drivers. Do you know how they are getting the money for that? From drug dealing, cheap fuel and tobacco smuggling, prostitution and car thefts.", 6);
		}
		else if(dialogID == 6)
		{
            ShowPlayerDialog("Nicole", "Sadly, the gang is aware of our actions, they know that we are after them. It made them more alert. But, luckily, the crime rate has dropped by 20%, so it's a progress. However, we have to fully stop them before they get any ideas about spreading their activities to another city.", 7);
		}
		else if(dialogID == 7)
		{
			ShowPlayerDialog("Nicole", "Our latest sources have reported that right now each member of the gang operates in separate districts of the city and invites only the best local drivers to their events to prevent any unnecessary attention from the police. Your job is to get the reputation, draw them out to the public and capture them.", 8);
		}
		else if(dialogID == 8)
		{
			ShowPlayerDialog("Nicole", "To get the reputation you will need a car. Luckily, there are a few arrested cars in our garage who's owners did not seem to be very eager to get them back. We will let you take one. Feel free to upgrade it, tune it, make it yours. Perhaps after everything is over we will make an exception for you to keep it.", 9);
		}
		else if(dialogID == 9)
		{
			ShowPlayerDialog("Nicole", "It is now popular to have a nickname and put it on the car's license plate. You should create one too. Make it simple and not too long, we won't be able to fit it on your car's numbers if you'll make it as big as your ego.", -1);
		}
		else if(dialogID == 10)
		{
			ShowPlayerDialog("Nicole", "Ah, we're almost there...", -1);
		}
		else if(dialogID == 11)
		{
			talker.CrossFadeInFixedTime("faceidle", 1);
			ShowPlayerChoices("What's in it for me?", "Decline", "Agree", "", 11);
		}
		else if(dialogID == 12)
		{
			ShowPlayerChoices("Inspect again", "Decline", "Take this one", "", 12);
		}
		else if(dialogID == 13)
		{
			ShowPlayerChoices("Inspect again", "Decline", "Take this one", "", 13);
		}
		else if(dialogID == 14)
		{
			ShowPlayerChoices("Inspect again", "Decline", "Take this one", "", 14);
		}
		else if(dialogID == 15)
		{
			ShowPlayerDialog("SMS(NICOLE)", "Icons with the star symbol mean the car meets. There you can show off your drifting skills and earn easy reputation. If you need some cash, you should check out the events labelled with the racing flag. These are the drag races. Keep in mind that these activities are only available during night. Completing one event advances time. Some locations will be visitable only during the day, the information about them can be displayed by hovering it with your cursor.", 16);
		}
		else if(dialogID == 16)
		{
			ShowPlayerDialog("SMS(NICOLE)", "For now we have information just about the illegal activites around the North town. I will update your map once we gather more details about other districts. Adding to that, even though your mission is to do street racing to catch them all, I would like to warn you not to overindulge in it. We are monitoring you and in case we see anything too suspicious - you're going back to jail with an extra year to your prison time for treason.", 17);
		}
		else if(dialogID == 17)
		{
			ShowPlayerDialog("SMS(NICOLE)", "How suspicious the police department is indicates the heat level at the top. Each illegal activity like racing and drifting adds to your heat level. In case you need to get it down, visit the police headquarters during daytime and I will give you some extra work that will clean up your name and you will get paid for it. On the other hand, people tend to forget things, so if you skip the night activities the heat should drop a little as well.", 18);
		}
		else if(dialogID == 18)
		{
			ShowPlayerDialog("SMS(NICOLE)", "That's all for now. If you have any more questions or something to report, visit me at the HQ and I will provide you with more information. It's getting late so I will go to bed. Having that in mind you should be able to get some action tonight and get your first reputation. Happy hunting!", -1);
		}
		else if(dialogID == 19)
		{
			ShowPlayerChoices("Report...", "Ask about...", "Say goodbye", "", 19);
		}
		else if(dialogID == 20)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("NICOLE", "First of all, you need to win the race to show them that you're just a regular racer and a good one. Adding to that, I bet some extra cash wouldn't do any bad to you either. Secondly, after you beat the guy, you have to follow him somewhere private and take him down. You know what they say - no pain, no gain. And don't forget that you're on our side now, no mistakes are allowed.", 21);
		}
		else if(dialogID == 21)
		{
			talker.CrossFadeInFixedTime("typing", 1);
			StartCoroutine(rotateTowards(talker.transform, -90f));
			ShowPlayerDialog("NICOLE", "Adding to that, I've done some researching on that guy you're after. His name is Kile Merinson, he's a mechanic. No crime history, the guy's part in this crew must be to patch up other members vehicles. It's just strange that he's into racing among the others, I guess he gets paid well for it as well.", 22);
		}
		else if(dialogID == 22)
		{
			talker.CrossFadeInFixedTime("prison_sitting2", 1);
			StartCoroutine(rotateTowards(talker.transform, -180f));
			ShowPlayerDialog("NICOLE", "Well, that's all I know for now, is there anything else you would like me to talk about?", 19);
		}
		else if(dialogID == 23)
		{
			talker.CrossFadeInFixedTime("handsUp", 1);
			ShowPlayerDialog("BOB", "Quite a view, right? Built it over the years... I use this place to fix up the wrecks that you guys carry in 'ere cryin' after losing like idiots.", 24);
		}
		else if(dialogID == 24)
	    {
			talker.CrossFadeInFixedTime("neutral", 1);
			talker.CrossFadeInFixedTime("handUp", 1);
			ShowPlayerDialog("BOB", "Anyway, you got a pile o' trash that needs fixin' - I'm your guy. I can turn an old tire and a few scraps into a fucking Mustang before you can say 'I prefer Porsche'. Got some nice parts come through 'ere, too. Just come to me and I'll do anything for ya.", 25);
		}
		else if(dialogID == 25)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			talker.CrossFadeInFixedTime("shrug", 1);
			ShowPlayerDialog("BOB", "Maybe I'll even get you a discount if you don't piss me off too much.", -1);
		}
		else if(dialogID == 26)
		{
			talker.CrossFadeInFixedTime("faceIdle", 1);
			ShowPlayerChoices("I need performance upgrades.", "I need visual upgrades.", "I want to ask you something.", "That's all.", 26);
		}
		else if(dialogID == 29)
		{
			ShowPlayerChoices("Why are you helping me?", "What do you know about these street races?", "That's all", "", 29);
			talker.CrossFadeInFixedTime("faceIdle", 1);
		}
		else if(dialogID == 30)
		{
			//talker.transform.rotation = Quaternion.RotateTowards(talker.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime);
			talker.transform.rotation = Quaternion.Euler(0f, -230f, 0f);
			dialogID = -1;
			afterDialogue = null;
			OnDialogResponse();
		}
	}
    void OnChoice1()
	{
		if(player)
		{
			Camera.main.GetComponent<MouseMove>().enabled=true;
		}
		choice1.SetActive(false);
		choice2.SetActive(false);
		choice3.SetActive(false);
		choice4.SetActive(false);
		choosing=false;
		choice1.GetComponent<Button>().onClick.RemoveListener(OnChoice1);
		choice2.GetComponent<Button>().onClick.RemoveListener(OnChoice2);
		choice3.GetComponent<Button>().onClick.RemoveListener(OnChoice3);
		choice4.GetComponent<Button>().onClick.RemoveListener(OnChoice4);
		if (dialogID == -1) {
			animator.SetBool ("isOpen", false);
		}
		else if(dialogID == 4)
		{
			talker.CrossFadeInFixedTime("happy", 1);
            ShowPlayerDialog("Nicole", "Well, according to your report, you still have 2 years here to save your soap from falling on the ground so you don't get a free anus width check from the locals. I'm sure getting you out of here is more than enough reward for your cooperation. Isn't that right?", 4);
		}
		else if(dialogID == 11)
        {
			talker.CrossFadeInFixedTime("sad", 1);
			ShowPlayerDialog("Prisoner", "I will ask my daughter to pay you. I am... was a business man, the money is not a trouble for my family.", 11);
		}
		else if(dialogID == 12)
		{
			ShowPlayerDialog("INSPECTING", "Confiscated for diesel and tobacco smuggling from foreign countries.\nFine: $4,870\nNot so fast but easy to control. Perfect for drifts.\nChoose this car?", 12);
		}
		else if(dialogID == 13)
		{
			ShowPlayerDialog("INSPECTING", "Confiscated for drunk driving and speeding.\r\nFine: $1100. \r\nAverage handling and speed. Good for drag races and drifts.\nChoose this one?", 13);
		}
		else if(dialogID == 14)
		{
			ShowPlayerDialog("INSPECTING", "Confiscated for reckless driving.\nFine: $600.\nGood speed, poor handling. Perfect for drag racing.\nChoose this one?", 14);
		}
		else if(dialogID == 19)
		{
			if(Game.current.mainQuest == 3)
			{
				talker.CrossFadeInFixedTime("happy", 1);
				ShowPlayerDialog("NICOLE", "Our tracking team has reported that you have received the first invitation from one of the group members. Perfect, it means that they are taking the bait. However, I'm sure other members will be keeping their eyes on your race for safety purposes, so take it slow with no suspicion raising actions.", 20);
			}
			//ShowPlayerChoices("Talk about the mission.", "Ask about...", "Say goodbye.", "", 19);
		}
		else if(dialogID == 22)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("NICOLE", "Our main goal of the mission is to stop the activities of the unnamed gang that is known for street racing, prostitution, smuggling and car thefts. Sadly, the only way we can track them down is by participating in their street racing activities for the best drivers in the city and that's where your role steps in. Earn enough reputation to get invitations to their events and take them out one by one.", 22);
		}
		else if(dialogID == 26)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			ShowPlayerDialog("BOB", "Wanna put more horses under that hood? No problem!", 27);
		}
		else if(dialogID == 29)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			talker.CrossFadeInFixedTime("shrug", 1);
			ShowPlayerDialog("BOB", "Help? Ya got it all wrong, kiddo. No one in this business just wants to 'help'. Nah, man, this is a mutual benefit type of relationship. Not that Imma start shagging your cousin for revenge after you dump me, ha! Anyway, I got a place, you got money - at all works out.", 29);
		}
	}
	void OnChoice2()
	{
		if(player)
		{
			Camera.main.GetComponent<MouseMove>().enabled=true;
		}
		choice1.SetActive(false);
		choice2.SetActive(false);
		choice3.SetActive(false);
		choice4.SetActive(false);
		choosing=false;
		choice1.GetComponent<Button>().onClick.RemoveListener(OnChoice1);
		choice2.GetComponent<Button>().onClick.RemoveListener(OnChoice2);
		choice3.GetComponent<Button>().onClick.RemoveListener(OnChoice3);
		choice4.GetComponent<Button>().onClick.RemoveListener(OnChoice4);
		if (dialogID == -1) {
			animator.SetBool ("isOpen", false);
		}
		else if(dialogID == 4)
		{
			talker.CrossFadeInFixedTime("sad", 1);
            ShowPlayerDialog("Nicole", "We've been thinking to put one of our skilled agents into this task. However, we were unable to find one with the experience from the crime world. After a while, we gathered some information about the local imprisoned criminals with the perfect driving skills. Only a few were suitable for the job and you're one of them. Will you accept this invitation?", 4);
		}
		else if(dialogID == 11)
        {
			Game.current.sideQuest1 = -1;
			talker.CrossFadeInFixedTime("sad", 1);
			ShowPlayerDialog("Prisoner", "Alright, I guess I'll have to find another person...", -1);
		}
		else if(dialogID == 12 || dialogID == 13 || dialogID == 14)
		{
			animator.SetBool ("isOpen", false);
			player.GetComponent<ThirdPersonUserControl>().enabled=true;
			Game.current.checking=false;
		}
		else if(dialogID == 19)
		{
			ShowPlayerChoices("...the main goal of the mission.", "...how to get reputation and money.", "...herself.", "...nothing.", 22);
		}
		else if(dialogID == 22)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("NICOLE", "To earn reputation, you have to show off your driving skills and the car meets are the best places to do that. However, likes from people won't bring you fortune, you'll have to do some street racing to earn it. Adding to that, I would like to remind you that working under my banner doesn't give you a permission to do illegal stuff. Other officers don't tolerate your presence and will put you back to jail if they see anything too much or too suspicious, keep that in mind.", 22);
		}
		else if(dialogID == 26)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			ShowPlayerDialog("BOB", "Not enough ladies' attention, eh? Let me help ya with that!", 28);
		}
		else if(dialogID == 29)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			talker.CrossFadeInFixedTime("shrug", 1);
			ShowPlayerDialog("BOB", "All I know is that it takes mad work to get cash and respect. You know how many crybabies have come in here with their slowpoke rides, looking for sympathy? The road ain't got no sympathy. You lose, you're out of your money. Just like that.", 29);
		}
	}
	void OnChoice3()
	{
		if(player)
		{
			Camera.main.GetComponent<MouseMove>().enabled=true;
		}
		choice1.SetActive(false);
		choice2.SetActive(false);
		choice3.SetActive(false);
		choice4.SetActive(false);
		choosing=false;
		choice1.GetComponent<Button>().onClick.RemoveListener(OnChoice1);
		choice2.GetComponent<Button>().onClick.RemoveListener(OnChoice2);
		choice3.GetComponent<Button>().onClick.RemoveListener(OnChoice3);
		choice4.GetComponent<Button>().onClick.RemoveListener(OnChoice4);
		if (dialogID == -1) {
			animator.SetBool ("isOpen", false);
		}
		else if(dialogID == 4)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
            ShowPlayerDialog("Nicole", "The majority of the information about this mission is confidential. You will receive the details once you agree to cooperate. For now, the only thing I can tell you is that your job will be to drive. Fast. Does it sound easy?", 4);
		}
		else if(dialogID == 11)
		{
			Game.current.sideQuest1 = 1;
			talker.CrossFadeInFixedTime("happy", 1);
			ShowPlayerDialog("Prisoner", "Oh thank you so much! I will never forget your kindness. Her name is Natasha, you will find her address on the letter. My name is Ivan, by the way, it was nice to meet you!", -1);
		}
		else if(dialogID == 12 || dialogID == 13 || dialogID == 14)
		{
			Game.current.carId = dialogID-11;
			Debug.Log(Game.current.carId);
			animator.SetBool ("isOpen", false);
			afterDialogue.SetActive(true);
			Game.current.checking=false;
		}
		else if(dialogID == 19)
		{
			//talker.CrossFadeInFixedTime("neutral", 1);
			StartCoroutine(rotateTowards(talker.transform, -90));
			talker.CrossFadeInFixedTime("typing", 2);
			ShowPlayerDialog("NICOLE", "Alright. Keep me updated on how it goes.", -1);
		}
		else if(dialogID == 22)
		{
			talker.CrossFadeInFixedTime("happy", 1);
			if(Game.current.mainQuest <= 3)
			{
				ShowPlayerDialog("NICOLE", "Hehe, I'm not sure if you're eligible to get that kind of information. All I can tell you right now is that I'm your boss and you should get back to work if you have no other questions.", 19);
			}
		}
		else if(dialogID == 26)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("BOB", "Ask away.", 29);
		}
		else if(dialogID == 29)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("BOB", "Let me know if ya need anythin.", 30);
		}
	}
	void OnChoice4()
	{
		if(player)
		{
			Camera.main.GetComponent<MouseMove>().enabled=true;
		}
		choice1.SetActive(false);
		choice2.SetActive(false);
		choice3.SetActive(false);
		choice4.SetActive(false);
		choosing=false;
		choice1.GetComponent<Button>().onClick.RemoveListener(OnChoice1);
		choice2.GetComponent<Button>().onClick.RemoveListener(OnChoice2);
		choice3.GetComponent<Button>().onClick.RemoveListener(OnChoice3);
		choice4.GetComponent<Button>().onClick.RemoveListener(OnChoice4);
		if (dialogID == -1) {
			animator.SetBool ("isOpen", false);
		}
		if(dialogID == 4)
		{
			talker.CrossFadeInFixedTime("happy", 1);
            ShowPlayerDialog("Nicole", "I'm glad to hear that! Though I must say I did expect you not to turn down this offer. I even prepared the papers for you to sign. Please do that right now and let's go to discuss the further details in my car. Don't forget to pack your things as well!", -1);
		}
		else if(dialogID == 22)
		{
			ShowPlayerChoices("Report...", "Ask about...", "Say goodbye", "", 19);
		}
		else if(dialogID == 26)
		{
			talker.CrossFadeInFixedTime("neutral", 1);
			ShowPlayerDialog("BOB", "Let me know if ya need anythin.", 30);
		}
	}
	public void ShowPlayerChoices(string choice_1, string choice_2, string choice_3, string choice_4, int dialogIDx)
	{
		StopAllCoroutines ();
		dialogueText.text = "";
		//nameText.text = PlayerPrefs ("Name");
		if(player)
		{
			Camera.main.GetComponent<MouseMove>().enabled=false;
		}
		choosing = true;
		dialogID = dialogIDx;
		choice1.SetActive (true);
		choice2.SetActive (true);
		choice1.GetComponentInChildren<Text>().text = choice_1;
		choice2.GetComponentInChildren<Text>().text = choice_2;
		choice1.GetComponent<Button>().onClick.AddListener(OnChoice1);
		choice2.GetComponent<Button>().onClick.AddListener(OnChoice2);
		if(choice_3 != "")
		{
			choice3.SetActive(true);
			choice3.GetComponentInChildren<Text>().text = choice_3;
			choice3.GetComponent<Button>().onClick.AddListener(OnChoice3);
		}
		if(choice_4 != "")
		{
			choice4.SetActive(true);
			choice4.GetComponentInChildren<Text>().text = choice_4;
			choice4.GetComponent<Button>().onClick.AddListener(OnChoice4);
		}
	}
	public void ShowPlayerDialog(string playerName, string dialogText, int dialogIDx)
	{
		if (!animator.GetBool ("isOpen")) {
			animator.SetBool ("isOpen", true);
		}
		dialogID = dialogIDx;
		nameText.text = playerName;
		StopAllCoroutines();
		StartCoroutine (TypeSentence (dialogText));
	}
	IEnumerator rotateTowards(Transform dude, float angle)
	{
		while(dude.eulerAngles.y != angle)
		{
			if(dude.eulerAngles.y > angle)
			{
				dude.eulerAngles = new Vector3(0, dude.eulerAngles.y-1, 0);
			}
			else
			{
				dude.eulerAngles = new Vector3(0, dude.eulerAngles.y+1, 0);
			}
			yield return null;
		}
	}
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
        typing = true;
		foreach (char letter in sentence.ToCharArray())
		{
            if(!typing)
            {
                dialogueText.text = sentence;
                break;
            }
			dialogueText.text += letter;
			yield return null;
		}
        typing = false;
	}
}
