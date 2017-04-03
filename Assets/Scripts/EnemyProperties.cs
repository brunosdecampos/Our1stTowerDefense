using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int maxHealth = 3;
    int health;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void ChangeHealth(int change)
    {
        health += change;
    }

    public int GetHealth()
    {
        return health;
    }
}
