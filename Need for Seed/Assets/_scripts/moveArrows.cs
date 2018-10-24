using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArrows : MonoBehaviour {

    public Texture arr1, arr2;
    Material m;
    public float speed = 0.7f;

    void Start () {
        m = GetComponent<Renderer>().material;
        StartCoroutine(change_to());
    }

    IEnumerator change_to()
    {
        yield return new WaitForSeconds(speed);
        m.SetTexture("_MainTex", arr2);
        StartCoroutine(change_back());
    }

    IEnumerator change_back()
    {
        yield return new WaitForSeconds(speed);
        m.SetTexture("_MainTex", arr1);
        StartCoroutine(change_to());
    }
}
