using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int maxHealth = 3;
    int health;
    public int enemyReward = 5;
    MoneyManager mm;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0)
        {
            mm.balance += enemyReward;
            Destroy(gameObject);
        }
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
