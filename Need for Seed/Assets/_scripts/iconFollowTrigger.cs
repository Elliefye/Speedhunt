using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconFollowTrigger : MonoBehaviour
{
    [SerializeField] Image template;
    [SerializeField] Transform player;
    [SerializeField] float opaqueDistance = 10;
    Image iconClone;

    void Start()
    {
        iconClone = Instantiate(template, Vector3.zero, Quaternion.zero).GetComponent<Image>();
    }
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        Vector3 visTest = Camera.main.WorldToViewportPoint(this.transform.position);
        if ((visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0)
        {
            Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
            iconClone.transform.position = namePose;
            if (distance < 10f)
            {
                iconClone.color = new Color32(255, 255, 255, (byte)(255 - 255*(distance/opaqueDistance)));
                //icon.rectTransform.sizeDelta = new Vector2(70 / distance, 70 / distance);
                //icon.color = new Color32(255, 255, 255, 255);
                //icon.gameObject.SetActive(true);
            }
            else
                icon.color = new Color32(255, 255, 255, 0);
        }
        else
            icon.color = new Color32(255, 255, 255, 0);
    }
    void OnMouseDown()
    {

    }
}
