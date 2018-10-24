using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenuOpen : MonoBehaviour {

    public Image blackscreen;
    public Camera cam;
    public GameObject pauseMenu;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            cam.GetComponent<SmoothMouseLook>().enabled = false;
            pauseMenu.SetActive(true);
            //GetComponent<Animator>().SetBool("pausedActive", true);
            blackscreen.color = new Color32(0, 0, 0, 227);
            Time.timeScale = 0;
        }
    }

    IEnumerator waitToOpen()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }
}
