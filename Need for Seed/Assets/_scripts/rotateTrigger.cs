using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTrigger : MonoBehaviour {

    public bool isTalking = false;
    public bool rotating = false;
    public float speed = 100;
    GameObject player;
   // Transform defpos;
    Quaternion defaultPos;

    private void Start()
    {
        //defpos.position = this.transform.position;
        defaultPos = this.transform.rotation;
        player = GameObject.FindWithTag("player");
    }
     
    void Update () {
        /*if (!rotating)
        {
            StartCoroutine(rotate());
        }*/
            //transform.LookAt(player.transform);
            //this.transform.rotation = defaultPos;
        if(isTalking)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
	}

    IEnumerator rotate()
    {
        rotating = true;
        if(isTalking)
        {
            while(transform.rotation.y != (-Quaternion.Euler(player.transform.rotation.eulerAngles).y))
            {
                //Vector3 rot = Quaternion.LookRotation(Quaternion.Euler(-player.transform.rotation.eulerAngles));
                transform.Rotate(0, 1, 0);
                yield return null;
            }
        }
        else
        {
            while (transform.rotation != defaultPos)
            {
                transform.Rotate(0, 1, 0);
                yield return null;
            }
        }
        rotating = false;
    }
}
