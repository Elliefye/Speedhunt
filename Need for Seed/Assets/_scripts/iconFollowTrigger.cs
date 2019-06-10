using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconFollowTrigger : MonoBehaviour
{
    public int roomNr = 0;
    public GameObject tracker;
    public Image icon;
    public GameObject player;
    public bool ableToGetActivated = true;
    public float opaqueDistance = 10;
    public float distance;

    void Update()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        Vector3 visTest = Camera.main.WorldToViewportPoint(this.transform.position);
        if (ableToGetActivated && (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0)
        {
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            icon.transform.position = namePose;
            if (distance < opaqueDistance)
            {
                icon.color = new Color32(255, 255, 255, (byte)(255 - 255*(distance/opaqueDistance)));
                //icon.rectTransform.sizeDelta = new Vector2(70 / distance, 70 / distance);
                //icon.color = new Color32(255, 255, 255, 255);
                //icon.gameObject.SetActive(true);
            }
            else
                icon.color = new Color32(255, 255, 255, 0);
        }
        else
            icon.color = new Color32(255, 255, 255, 0);

        if(tracker != null)
        {
            if (roomNr != tracker.GetComponent<roomNr>().currentRoom)
            {
                ableToGetActivated = false;
                icon.gameObject.SetActive(false);
            }
            else ableToGetActivated = true;
        }
    }
}
