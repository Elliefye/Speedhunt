using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene2 : MonoBehaviour {

	public Vector3 position;
	public float rotationy;
	public GameObject animator1;
	public GameObject animator2;
	public GameObject camera;
    public GameObject cutscene;
	public GameObject fader;
    private bool checking=false;
    private changeIcon component;
    public GameObject hint2;
    private void Start()
    {
        component = GetComponent<changeIcon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        hint2.SetActive(true);
    }
    // Use this for initialization
    void Update () {
        if(component.iconChanged && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && (!checking))
        {
            checking=true;
            animator1.transform.localPosition = position;
            animator1.transform.rotation = Quaternion.AngleAxis(rotationy, Vector3.up);
            animator1.GetComponent<Animator>().enabled = false;
            animator2.GetComponent<Animator>().SetInteger("Animstate", 1);
            camera.SetActive(false);
            fader.SetActive(false);
            fader.SetActive(true);
            cutscene.SetActive(true);
        }
	}
}
