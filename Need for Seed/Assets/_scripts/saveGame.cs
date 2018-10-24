using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGame : MonoBehaviour {

    private void Awake()
    {
        SaveLoad.Save();
    }
}
