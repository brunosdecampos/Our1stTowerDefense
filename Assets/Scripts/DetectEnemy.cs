using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    TowerShoot ts;

	// Use this for initialization
	void Start ()
    {
        ts = transform.parent.GetChild(1).GetComponent<TowerShoot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            ts.targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            ts.targets.Remove(other.gameObject);
        }
    }
}
