using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour {

    // Use this for initialization
    public int whichScene;
	void Start () {
        SceneManager.LoadScene(whichScene, LoadSceneMode.Single);
    }
}
