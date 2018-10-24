using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeIcon : MonoBehaviour
{
    public Image attention;
    public Text dot, text_trigger;
    public Sprite icon_dot, icon_trigger; 
    public float distance, distance2;
    public bool isPlayerNear, iconChanged;
    public GameObject interaction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
            isPlayerNear = false;
    }

    private void Update()
    {
        distance = Vector2.Distance(dot.transform.position, attention.transform.position);

        if ((distance <= 100) && (isPlayerNear))
        {
            iconChanged = true;
            attention.rectTransform.sizeDelta = new Vector2(50, 50);
            attention.sprite = icon_trigger;
            attention.color = new Color32(255, 255, 255, 255);
            text_trigger.gameObject.SetActive(true);
        }
        else
        {
            iconChanged = false;
            attention.rectTransform.sizeDelta = new Vector2(30, 30);
            attention.sprite = icon_dot;
            distance2 = GetComponent<iconFollowTrigger>().distance;
            //attention.rectTransform.sizeDelta = new Vector2(70 / distance, 70 / distance);
            //attention.color = new Color32(255, 255, 255, (byte)(170 / distance2));
            text_trigger.gameObject.SetActive(false);
        }
        if (iconChanged && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && !Game.current.checking && interaction)
        {
            Game.current.checking = true;
            interaction.SetActive(false);
            interaction.SetActive(true);
        }
    }
}
