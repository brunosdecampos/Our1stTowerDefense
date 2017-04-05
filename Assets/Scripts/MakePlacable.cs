using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlacable : MonoBehaviour
{
    TowerMove tm;
    TowerShoot ts;

    // Use this for initialization
    void Start ()
    {
        tm = transform.parent.parent.GetComponent<TowerMove>();
        ts = transform.parent.parent.GetChild(1).GetComponent<TowerShoot>();
    }
	
	// Update is called once per frame
	void Update ()
    {		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!ts.placed)
        {
            if (other.gameObject.tag.Equals("PathBox") || other.gameObject.tag.Equals("Castle"))
            {
                tm.placable = false;
                transform.parent.parent.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                transform.parent.parent.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                transform.parent.parent.GetChild(0).GetChild(2).GetComponent<Renderer>().material.color = Color.red;
                transform.parent.parent.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                transform.parent.parent.GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!ts.placed)
        {
            if (other.gameObject.tag.Equals("PathBox") || other.gameObject.tag.Equals("Castle"))
            {
                tm.placable = true;
                transform.parent.parent.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = tm.oldColors[0];
                transform.parent.parent.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = tm.oldColors[0];
                transform.parent.parent.GetChild(0).GetChild(2).GetComponent<Renderer>().material.color = tm.oldColors[0];
                transform.parent.parent.GetChild(1).GetChild(0).GetComponent<Renderer>().material.color = tm.oldColors[0];
                transform.parent.parent.GetChild(1).GetChild(1).GetComponent<Renderer>().material.color = tm.oldColors[0];
            }
        }
    }
}
