using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public bool map = false;
    public Text dayNr;
    public Image image;
    public int speed = 3;
    public CanvasGroup canvas;
    bool first = true;
    public bool roomChanged = false;

    void Start () {
        StartCoroutine(FadeFromBlack(image));
        if(canvas)
        {
            canvas.interactable = false;
        }
	}

    private void Update()
    {
        if (roomChanged)
        {
            StartCoroutine(FadeFromBlack(image));
            roomChanged = false;
        }
            
    }

    IEnumerator FadeFromBlack(Image image)
    {
        if((map) && (!Game.current.isNight) && (first))
        {
            first = false;
            dayNr.text += Game.current.dayNr;
            dayNr.gameObject.SetActive(true);
            StartCoroutine(FlashDay(dayNr));
        }
        for (int i = 255; i > 0; i -= speed)
        {
            image.color = new Color32(0, 0, 0, (byte)i);
            //yield return new WaitForSeconds((float)0.001);
            yield return null;
        }
        image.gameObject.SetActive(false);
        if (canvas != null)
           canvas.interactable = true;
    }

    IEnumerator FlashDay(Text day)
    {
        for (int i = 255; i >= 0; i -= 1)
        {
            day.color = new Color32(255, 255, 255, (byte)i);
            yield return null;
        }
        day.gameObject.SetActive(false);
    }
}
