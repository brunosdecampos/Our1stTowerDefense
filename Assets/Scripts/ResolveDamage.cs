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
		float factor = 1;
		if(other.gameObject.tag.Equals("Enemy"))
        {
			EnemyProperties ep = other.gameObject.GetComponent<EnemyProperties>();

			if (gameObject.tag.Equals (ep.weakness) ) 
			{
				factor = ep.weaknessFactor;
			} 
			else if (gameObject.tag.Equals (ep.strength) ) 
			{
				factor = ep.strengthFactor;
			}

			ep.ChangeHealth(Mathf.RoundToInt(-projectileStrength * factor));
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("KillPlane"))
        {
            Destroy(gameObject);
        }
    }
}
