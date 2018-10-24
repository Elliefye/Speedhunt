using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartMenuButtons : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject startNew;
    public Button loadg;
    public Button newg;
    public Button options;
    public Button exit;
    public Button goback;
    public Image exitscreen;
    public Button yes;
    public Button cancel;
    private bool loadGameExists;

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Progress.nfs"))
            loadGameExists = true;
        else loadGameExists = false;
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ExitCancel()
    {
        exitscreen.gameObject.SetActive(false);
        loadg.gameObject.SetActive(loadGameExists);
        newg.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        goback.gameObject.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Exit()
    {
        exitscreen.gameObject.SetActive(true);
        loadg.gameObject.SetActive(false);
        newg.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    public void openOptions()
    {
        goback.gameObject.SetActive(true);
        loadg.gameObject.SetActive(false);
        newg.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void backToStart()
    {
        goback.gameObject.SetActive(false);
        //loadg.gameObject.SetActive(loadGameExists);
        loadg.gameObject.SetActive(loadGameExists);
        newg.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        optionsMenu.SetActive(false);
        exit.gameObject.SetActive(true);
    }

    public void startNewGame()
    {
        startNew.SetActive(true);
    }
}
