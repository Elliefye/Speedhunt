using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spikestrips : MonoBehaviour {

	public GameObject wheel;
	public GameObject wheel2;
	public Image FadeImg;
	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.tag == "player") {
			wheel.GetComponent<Wheel> ().popped=true;;
			wheel2.GetComponent<Wheel> ().popped=true;
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
        AsyncOperation async = SceneManager.LoadSceneAsync(2); //Application.LoadLevelAsync(scene);
    }
}
