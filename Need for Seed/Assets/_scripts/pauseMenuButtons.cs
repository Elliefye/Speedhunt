using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenuButtons : MonoBehaviour {

    public Button resume;
    public Button restart;
    public Button options;
    public Button exit;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject exitMenu;
    public Camera cam;
    public Image blackscreen;
    int sceneId;


    void Start () {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        if ((sceneId != 2) || (sceneId != 3) || (sceneId != 7)) //race scenes
            restart.interactable = false;
        //cam = Camera.current;
    }
	
	public void resumeGame()
    {
        blackscreen.color = new Color32(0, 0, 0, 0);
        Time.timeScale = 1;
        cam.GetComponent<SmoothMouseLook>().enabled = true;
        pauseMenu.SetActive(false);
    }
		
	public void CancelExit()
    {
        exitMenu.SetActive(false);
        if ((sceneId == 2) || (sceneId == 3) || (sceneId == 7))
            restart.interactable = true;
        resume.interactable = true;
        options.interactable = true;
        exit.interactable = true;
    }

    public void OpenExitMenu()
    {
        exitMenu.SetActive(true);
        if (restart.interactable)
            restart.interactable = false;
        resume.interactable = false;
        options.interactable = false;
        exit.interactable = false;
    }

    public void openOptions()
    {
        optionsMenu.SetActive(true);
        restart.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    public void closeOptions()
    {
        restart.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1;
    }
}
