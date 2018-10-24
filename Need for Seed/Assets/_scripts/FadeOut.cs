using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image blackscreen;
    public int speed = 3;
    public bool roomChange = false;
	public GameObject startscript;
    public GameObject fadeIn;
    bool fading = false;

    void Update()
    {
        if (roomChange && !fading)
            StartCoroutine(FadeToBlack());      
    }

    IEnumerator FadeToBlack()
    {
        fading = true;
        if (!blackscreen.gameObject.activeSelf)
            blackscreen.gameObject.SetActive(true);

        for (int i = 0; i <= 255; i += speed)
        {
            blackscreen.color = new Color32(0, 0, 0, (byte)i);
            yield return null;
            //yield return new WaitForSeconds((float)0.001);
        }
        blackscreen.color = new Color32(0, 0, 0, 255);

        if (roomChange)
        {
            GetComponent<FadeIn>().roomChanged = true;
            roomChange = false;
        }
        fading = false;
		OnFadeComplete ();
    }

	void OnFadeComplete()
	{
		if (startscript) {
			startscript.active = true;
		}
	}
}
