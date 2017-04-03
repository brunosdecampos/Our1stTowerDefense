using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    TowerShoot ts;

	// Use this for initialization
	void Start ()
    {
        ts = transform.GetChild(0).GetComponent<TowerShoot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!ts.placed)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
            pos.y = 0.5f;
            transform.position = pos;
            Debug.Log(pos);
            if(Input.GetMouseButtonDown(0))
            {
                //Set materials to opaque
                Color oldColor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
                transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
                transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);

                //Enable colliders
                GetComponent<Collider>().enabled = true;
                transform.GetChild(0).GetComponent<Collider>().enabled = true;
                transform.GetChild(1).GetComponent<Collider>().enabled = true;
                transform.GetChild(0).GetChild(0).GetComponent<Collider>().enabled = true;

                ts.placed = true;
            }
        }
    }
}
