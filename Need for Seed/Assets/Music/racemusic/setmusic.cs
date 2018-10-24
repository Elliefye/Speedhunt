using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setmusic : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] music;
	private int whichmusic;
	private AudioSource audioSource;
	public AudioClip[] endings;
	void Start () {
		whichmusic = Mathf.RoundToInt(Random.Range(0f, music.Length-1));
		audioSource = this.GetComponent<AudioSource>();
		audioSource.clip = music[whichmusic];
		audioSource.Play();
	}
	public void endingMusic()
	{
		audioSource.clip = endings[whichmusic];
		audioSource.Play();
	}
}
