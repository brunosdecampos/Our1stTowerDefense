using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 2;
        }
        else
        {
            if (Time.timeScale > 1)
            {
                Time.timeScale = 1;
            }
        }
	}
}
