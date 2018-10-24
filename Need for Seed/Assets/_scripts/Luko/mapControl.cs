using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mapControl : MonoBehaviour {

    public int whichScene;
	public int sceneVar;
	public Image FadeImg;
	void OnMouseEnter()
	{
		this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("showinfo", true);
	}
	void OnMouseExit()
	{
		this.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("showinfo", false);
	}
	void OnMouseOver()
	{
		Debug.Log(FadeImg.color.a);
		if (Input.GetMouseButton(0) && FadeImg.color.a == 1f)
        {
			FadeImg.canvasRenderer.SetAlpha(0.0f);
        	FadeImg.CrossFadeAlpha(1.0f, 2, false);
        	StartCoroutine("FadeOut");
		}
	}
	IEnumerator FadeOut()
    {
        float amount = 1;
        while(amount > 0)
        {
            amount -= Time.deltaTime / 2;
            AudioListener.volume = amount;
            yield return null;
        }
        SceneManager.LoadScene(whichScene, LoadSceneMode.Single);
    }
}
