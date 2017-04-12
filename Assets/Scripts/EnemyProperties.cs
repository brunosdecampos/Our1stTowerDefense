using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperties : MonoBehaviour
{
    public int maxHealth = 3;
	public int enemyReward = 5;
	public int killScore = 10;
	public float scoreDownDelay = 2;
	public string weakness = "fire";
	public float weaknessFactor = 1.5f;
	public string strength = "wood";
	public float strengthFactor = 0.5f;


	float scoreTimer;
	MoneyManager mm;
    int health;
    GameObject gameController;
    GameController gc;
    Score score;
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
                gameController.transform.GetChild(0).GetChild(6).GetComponent<Button>().enabled = true;
                gameController.transform.GetChild(0).GetChild(6).GetComponent<Image>().enabled = true;
                gameController.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Text>().enabled = true;
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
