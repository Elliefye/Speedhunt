using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class loadEnable : MonoBehaviour {

    private bool loadGameExists;
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/Progress.nfs"))
            loadGameExists = true;
        else loadGameExists = false;
        this.gameObject.SetActive(loadGameExists);
    }
}
