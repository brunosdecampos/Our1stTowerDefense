using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToMoveDir : MonoBehaviour
{
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rb.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity, transform.up);
        }
	}
}
