using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public List<GameObject> enemyPrefab;
	public float enemyCreationTime = 3;
	public string enemyOrder;
	float timer = 0;
	int enemyIndex; // next enemy

	// Use this for initialization
	void Start () {
		enemyIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		int enemyType;

		if (enemyIndex < enemyOrder.Split (',').GetLength(0)) {	// if the enemyOrder is not finished
			if (Time.time > timer) {
				Debug.Log("index: "+enemyIndex.ToString()+": "+ enemyOrder.Split(',')[enemyIndex]);
				enemyType = System.Convert.ToInt32 (enemyOrder.Split(',')[enemyIndex]);
				enemyIndex++;
//				Debug.Log (enemyType.ToString ());

				timer = Time.time + enemyCreationTime;

				if (enemyType > 0) { // is there an enemy in turn?
					Instantiate (enemyPrefab [enemyType - 1], new Vector3 (-17, 0.5f, -8), Quaternion.identity);
				} else {
					timer += enemyCreationTime * 4;		// extra time with enemyType = 0
				}

			}
		}
        else
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("game over");
            }
        }
	}
}
