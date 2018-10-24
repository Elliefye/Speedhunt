using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragstart : MonoBehaviour {

	public Transform enemycars;
	public Transform playercars;
	public Transform racewaypoints;
	public Transform camera;
	public Transform finishline;
	public Text timetext;
	public Text percenttext;
	private float stagetime = 0f;
	// Use this for initialization
	void Start () {
		playercars.gameObject.GetComponent<FollowAI> ().enabled = true;
		enemycars.gameObject.GetComponent<FollowAI> ().target = racewaypoints;
		enemycars.gameObject.GetComponent<FollowAI> ().speed = 1;
	}
	void FixedUpdate()
	{
		stagetime += Time.deltaTime;
		float completed = Vector3.Distance(playercars.position, finishline.position);
		Debug.Log(completed);
		float dist = Vector3.Distance(enemycars.position, finishline.position)-completed;
		percenttext.text = ((784f-completed)/7.84).ToString("F0") + "%";
		timetext.text = stagetime.ToString("F1") + "s";
		if(dist > 5f)
		{
			dist = 5f;
		}
		else if(dist < -5f)
		{
			dist = -5f;
		}
		camera.localPosition = new Vector3(camera.localPosition.x,camera.localPosition.y,dist);
	}
}