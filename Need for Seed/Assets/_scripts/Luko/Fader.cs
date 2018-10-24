using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	// Use this for initialization
	public Image FadeImg;
	public bool fadein = true;
	public float fadeSpeed = 1.5f;
	public GameObject script;
    public bool silence = true;
	void OnEnable () {
		if(fadein)
		{
            fadeIn();
		}
		else
		{
            fadeOut();
		}
	}
    public void fadeOut()
    {
        FadeImg.canvasRenderer.SetAlpha(1f);
        FadeImg.CrossFadeAlpha(0f, fadeSpeed, false);
        AudioListener.volume = 1;//we want to make the image completely transparent
    }
    public void fadeIn()
    {
        FadeImg.canvasRenderer.SetAlpha(0.0f);
        FadeImg.CrossFadeAlpha(1.0f, fadeSpeed, false);
        StartCoroutine(FadeOut(fadeSpeed));
        //Invoke("OnFadeComplete", fadeSpeed);
    }
    IEnumerator FadeOut(float FadeTime)
    {
        float amount = 1;
        while(amount > 0)
        {
            amount -= Time.deltaTime / FadeTime;
            if (silence)
            {
                AudioListener.volume = amount;
            }
            yield return null;
        }

        if (script)
        {
            script.active = false;
            script.active = true;
        }
    }
}
