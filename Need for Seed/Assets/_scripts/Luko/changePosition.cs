using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePosition : MonoBehaviour {

    private changeIcon component;
    public Image FadeImg;
    public GameObject player;
    public AudioClip doorSound;
    public AudioClip doorSound2;
    // Use this for initialization

    // Update is called once per frame
    void OnEnable()
    {
            FadeImg.canvasRenderer.SetAlpha(0.0f);
            FadeImg.CrossFadeAlpha(1.0f, 1.5f, false);
            Invoke("OnFadeComplete", 1.5f);
            AudioSource.PlayClipAtPoint(doorSound, player.transform.position);
    }
    private void OnFadeComplete()
    {
        FadeImg.canvasRenderer.SetAlpha(1f);
        FadeImg.CrossFadeAlpha(0f, 1.5f, false); //we want to make the image completely transparent
        player.transform.position = this.transform.position;
        player.transform.rotation = this.transform.rotation;
        AudioSource.PlayClipAtPoint(doorSound2, player.transform.position);
        Game.current.checking = false;
    }
}
