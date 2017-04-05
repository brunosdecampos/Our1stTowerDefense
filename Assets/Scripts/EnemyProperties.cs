using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int maxHealth = 3;
    int health;
    public int enemyReward = 5;
    MoneyManager mm;
    GameObject gameController;
    GameController gc;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        mm = gameController.GetComponent<MoneyManager>();
        gc = gameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                Destroy(gameObject);
                mm.balance += enemyReward;
            }
            else
            {
                gc.winText.text = "You lost...";
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().enabled = false;
                Destroy(gameObject);
            }
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
