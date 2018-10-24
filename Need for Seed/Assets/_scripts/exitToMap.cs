using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitToMap : MonoBehaviour {

    public GameObject exitToMapPopup;

    void Update () {
        if (GetComponent<changeIcon>().iconChanged && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
            exitToMapPopup.SetActive(true);  
    }
}
