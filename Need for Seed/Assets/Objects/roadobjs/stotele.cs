using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stotele : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<BoxCollider>().enabled = true;
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
