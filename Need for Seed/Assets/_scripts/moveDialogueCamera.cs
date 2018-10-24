using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDialogueCamera : MonoBehaviour {

    public Transform target;
    public GameObject camera, cutscene;
	void Start ()
    {
        camera.transform.position = target.position;
        camera.transform.rotation = target.rotation;
    }
	
	public void End()
    {
        cutscene.SetActive(false);
    }
}
