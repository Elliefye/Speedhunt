using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowMouse : MonoBehaviour {
    public Transform cameraTransform;
    public float shakeLength = 5;
    public float shakeTimer;
    public float shakeAmount = 0.4f;
    public float shakeSpeed = 0.2f;
    public bool isShaking = false;
    public bool shakeOnce = false;
    Vector3 originalPos;
    Vector3 newPos;

    void Awake()
    {
        shakeTimer = shakeLength;
    }

    void OnEnable()
    {
        originalPos = cameraTransform.position;
    }

    void Update()
    {
        if (!isShaking)
        {
            shakeOnce = true;
            shakeTimer = shakeLength;
            newPos = cameraTransform.position;
        }

        if (shakeOnce)
        {
            Shake();
        }
    }

    public void Shake()
    {
        if (shakeTimer > 0)
        {
            isShaking = true;

            if (Vector3.Distance(newPos, cameraTransform.position) <= shakeAmount / 30)
                newPos = originalPos + Random.insideUnitSphere * shakeAmount;

            cameraTransform.position = Vector3.Slerp(cameraTransform.position, newPos, Time.deltaTime * shakeSpeed);
        }
        else
        {
            shakeTimer = 0f;
            cameraTransform.position = originalPos;
            isShaking = false;
            shakeOnce = false;
        }
    }
}
