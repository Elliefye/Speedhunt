using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficgo : MonoBehaviour {
	
	// Update is called once per frame
    private Rigidbody rb;
    public float speed=20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward*-speed;
    }
}
