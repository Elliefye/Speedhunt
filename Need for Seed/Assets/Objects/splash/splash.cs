using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class splash : MonoBehaviour {

	// Use this for initialization
	public GameObject title;
	void Start () {
		if (File.Exists(Application.persistentDataPath + "/Progress.nfs"))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/Progress.nfs", FileMode.Open);
            //Game.current = (Game)bf.Deserialize(file);
            //file.Close();
			//title.SetActive(true);
			StartCoroutine(LoadScene());
			Debug.Log("Krauna");
        }
		else
		{
			StartCoroutine(LoadScene());
			Debug.Log("Krauna");
		}
	}
	IEnumerator LoadScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(1); //Application.LoadLevelAsync(scene);
        while (!async.isDone)
        {
            	yield return null;
        }
	}
}
