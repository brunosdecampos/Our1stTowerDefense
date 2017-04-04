using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    EnemyProperties ep;
    Vector3 scale;

	// Use this for initialization
	void Start ()
    {
        ep = transform.parent.GetComponent<EnemyProperties>();
        scale = transform.localScale;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.localScale = new Vector3(ep.GetHealth() / (float)ep.maxHealth, scale.y, scale.z);
    }
}
