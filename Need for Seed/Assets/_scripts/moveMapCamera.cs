using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMapCamera : MonoBehaviour {

    public float speed = 1.0f;
    public float sensitivity = 0.05f;
    public float moveSensitivity = 3; // 1/3 of the screen
    public float clampLeftO = -10, clampRightO = 12, clampTopO = 25, clampBottomO = -27, //zoomed out
        zoomMin = 15, zoomMax = 35,
        clampLeftI = -34, clampRightI = 34, clampTopI = 40, clampBottomI = -40; //zoomed in
    private float limitXLeft, limitXRight, limitYTop, limitYBottom, zoomFactor = 0;
    private Camera current;

    private void Start()
    {
        limitXLeft = Screen.width / moveSensitivity;
        limitXRight = Screen.width / moveSensitivity * (moveSensitivity - 1);
        limitYBottom = Screen.height / moveSensitivity;
        limitYTop = Screen.height / moveSensitivity * (moveSensitivity - 1);
        current = GetComponent<Camera>();
    }

    void Update () {
        zoomFactor = zoomMax - current.transform.position.y;

        if (Input.mousePosition.x < limitXLeft)
            current.transform.position = new Vector3(current.transform.position.x - speed, current.transform.position.y, current.transform.position.z);
        else if(Input.mousePosition.x > limitXRight)
            current.transform.position = new Vector3(current.transform.position.x + speed, current.transform.position.y, current.transform.position.z);

        if (Input.mousePosition.y < limitYBottom)
            current.transform.position = new Vector3(current.transform.position.x, current.transform.position.y, current.transform.position.z - speed);
        else if(Input.mousePosition.y > limitYTop)
            current.transform.position = new Vector3(current.transform.position.x, current.transform.position.y, current.transform.position.z + speed);

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
            current.transform.position = new Vector3(current.transform.position.x, current.transform.position.y - 1, current.transform.position.z);
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            current.transform.position = new Vector3(current.transform.position.x, current.transform.position.y + 1, current.transform.position.z);

        current.transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, (clampLeftO + ((clampLeftI - clampLeftO) / (zoomMax - zoomMin) * zoomFactor)), (clampRightO + ((clampRightI - clampRightO) / (zoomMax - zoomMin) * zoomFactor))),
          Mathf.Clamp(transform.position.y, zoomMin, zoomMax),
          Mathf.Clamp(transform.position.z, (clampBottomO + ((clampBottomI - clampBottomO) / (zoomMax - zoomMin) * zoomFactor)), (clampTopO + ((clampTopI - clampTopO) / (zoomMax - zoomMin) * zoomFactor))));
    }
}
