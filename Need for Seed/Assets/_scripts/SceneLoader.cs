using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private bool loadScene = false;
    public Image blackscreen;
    public int speed = 3;
    public bool loadOnStart = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;

    private void Start()
    {
        if (loadOnStart)
            ButtonPressed();
    }


    private void Update()
    {
        if(loadScene == true && loadingText != null)
           loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
    }

    public void ButtonPressed()
    {
        loadScene = true;
        if(loadingText)
        {
            loadingText.gameObject.SetActive(true);
        }
        //blackscreen.color = new Color32(0, 0, 0, 255);
        StartCoroutine(FadeToBlack());
        //StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene()
    {
        //yield return new WaitForSeconds(5);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene); //Application.LoadLevelAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        if (!blackscreen.gameObject.activeSelf)
            blackscreen.gameObject.SetActive(true);

        for (int i = 0; i <= 255; i += speed)
        {

            blackscreen.color = new Color32(0, 0, 0, (byte)i);
            Debug.Log(i);
            yield return null;
            //yield return new WaitForSeconds((float)0.001);
        }
        blackscreen.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LoadNewScene());
    }
}