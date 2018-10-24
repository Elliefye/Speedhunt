using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform target;

    void Update () {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 360);
    }
}
