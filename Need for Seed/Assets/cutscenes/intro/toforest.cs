using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toforest : MonoBehaviour {

    public Image FadeImg;
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
        if(other.tag == "player")
        {
           FadeImg.canvasRenderer.SetAlpha(0.0f);
           FadeImg.CrossFadeAlpha(1.0f, 1f, false);
           StartCoroutine(FadeOut(1.5f));
        }
    }
	
    IEnumerator FadeOut(float FadeTime)
    {
        float amount = 1;
        while (amount > 0)
        {
            amount -= Time.deltaTime / FadeTime;
            AudioListener.volume = amount;
            yield return null;
        }
        //AsyncOperation async = SceneManager.LoadSceneAsync(8); //Application.LoadLevelAsync(scene);
    }
}
