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
    Score score;
    public int killScore = 10;
    float scoreTimer;
    public float scoreDownDelay = 2;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        mm = gameController.GetComponent<MoneyManager>();
        gc = gameController.GetComponent<GameController>();
        score = gameController.GetComponent<Score>();
        scoreTimer = Time.time + scoreDownDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (killScore > 1)
        {
            if (Time.time > scoreTimer)
            {
                killScore--;
                scoreTimer = Time.time + scoreDownDelay;
            }
        }
        if(health <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                Destroy(gameObject);
                mm.balance += enemyReward;
                score.scoreNum += killScore;
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
