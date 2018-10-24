using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class loadGame : MonoBehaviour {

    void Start()
    {
	if(Game.current.cash == null)
	{
	   Debug.Log("YES");
           if (File.Exists(Application.persistentDataPath + "/Progress.nfs"))
           {
           	BinaryFormatter bf = new BinaryFormatter();
           	 FileStream file = File.Open(Application.persistentDataPath + "/Progress.nfs", FileMode.Open);
            	Game.current = (Game)bf.Deserialize(file);
           	 file.Close();
           }
    	}
    }
}
