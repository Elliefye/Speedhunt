using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
	public Transform player;
float MouseX;
float MouseY;
float Xbuffer;
float Ybuffer;

void Start ()
{
MouseX = player.rotation.x;
}
void OnEnable()
{
	Cursor.lockState = CursorLockMode.Locked;
	Cursor.visible = false;
}
void OnDisable()
{
	Cursor.lockState = CursorLockMode.None;
	Cursor.visible = true;
}
void Update ()
{
Xbuffer += Input.GetAxis ("Mouse X");
Ybuffer += Input.GetAxis ("Mouse Y");
MouseX += Xbuffer / 2;
MouseY += Ybuffer / 2;

Xbuffer *= 0.75f;
Ybuffer *= 0.75f;
if (Ybuffer >= 0)
{
if (MouseY < 70)
{
transform.localRotation = Quaternion.Euler (-MouseY, 176.729f, 0f);
}else{
MouseY = 70;
}
}else if(Ybuffer < 0)
{
if(MouseY > -70)
{
transform.localRotation = Quaternion.Euler (-MouseY, 176.729f, 0f);
}else{
MouseY = -70;
}
}
player.transform.rotation = Quaternion.Euler (0f, MouseX, 0f);
}
}