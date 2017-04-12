using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public List<GameObject> enemyPrefab;
	public float enemyCreationTime = 1;
	public float enemyDelayTime = 4;
	public string enemyOrder;
	public Vector3 startPos;
	public int numOfWaypoints = 6;
	float timer = 0;
	int enemyIndex; // next enemy
	int enemyTotal;
    public Text winText;
    EnemyProperties castle_ep;
    Score score;
    MoneyManager mm;
	Text enemyLeftText;
	string[] enemyList;
	bool end = false;
    private const string prefsName = "lastLevelBeaten";

	// Use this for initialization
	void Start () {
		enemyIndex = 0;
        winText = transform.GetChild(0).GetChild(2).GetComponent<Text>();
        winText.text = "";
        castle_ep = GameObject.FindGameObjectWithTag("Castle").GetComponent<EnemyProperties>();
		enemyTotal = enemyOrder.Replace(",","").Replace("0","").Length;

		enemyLeftText = transform.GetChild(0).GetChild(4).GetComponent<Text>();
		enemyLeftText.text = "Enemies left: " + enemyTotal.ToString ();

		enemyList = enemyOrder.Split (',');
        score = GetComponent<Score>();
        mm = GetComponent<MoneyManager>();
    }

	// Update is called once per frame
	void Update () {
		int enemyType;

		if (enemyIndex < enemyList.Length) {	// if the enemyOrder is not finished
			if (Time.time > timer) {
				Debug.Log("index: " + enemyIndex.ToString() + ": " + enemyList[enemyIndex]);
				enemyType = System.Convert.ToInt32 (enemyList[enemyIndex]);
				enemyIndex++;
//				Debug.Log (enemyType.ToString ());

				timer = Time.time + enemyCreationTime;

				if (enemyType > 0) { // is there an enemy in turn?
					Instantiate (enemyPrefab [enemyType - 1], startPos, Quaternion.identity);
					enemyTotal--;
					enemyLeftText.text = "Enemies left: " + enemyTotal.ToString ();
				} else {
					timer += enemyDelayTime;		
				}

			}
		}
		else if (!end)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                if (castle_ep.GetHealth() > 0)
                {
					end = true;
                    winText.text = "YOU WIN!";
                    int sceneNum = SceneManager.GetActiveScene().buildIndex;
                    if (PlayerPrefs.HasKey(prefsName))
                    {
                        if (PlayerPrefs.GetInt(prefsName) > sceneNum)
                        {
                            PlayerPrefs.SetInt(prefsName, sceneNum);
                            PlayerPrefs.Save();
                            print(PlayerPrefs.GetInt(prefsName));
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt(prefsName, sceneNum);
                        PlayerPrefs.Save();
                        print(PlayerPrefs.GetInt(prefsName));
                    }
                    transform.GetChild(0).GetChild(6).GetComponent<Button>().enabled = true;
                    transform.GetChild(0).GetChild(6).GetComponent<Image>().enabled = true;
                    transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Text>().enabled = true;
                    score.scoreNum += score.levelClearBonus;
                    score.scoreNum += mm.balance * score.moneyBonus;
                    score.scoreNum += castle_ep.GetHealth() * score.castleBonus;
                }
            }
        }
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
