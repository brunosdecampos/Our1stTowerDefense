using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveDamage : MonoBehaviour
{
    public int projectileStrength = 1;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            EnemyProperties ep = other.gameObject.GetComponent<EnemyProperties>();
            ep.ChangeHealth(-projectileStrength);
            Destroy(gameObject);
        }
    }
}
