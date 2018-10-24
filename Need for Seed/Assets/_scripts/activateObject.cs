using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObject : MonoBehaviour
{
    public GameObject activate;

    void Start()
    {
        activate.SetActive(true);
    }
}
