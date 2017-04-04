using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public List<GameObject> enemyPrefab;
	public float enemyCreationTime = 3;
	float timer = 0;

	// Use this for initialization
	void Start () {
	//	Instantiate(enemyPrefab, new Vector3 (-10, 0.5f, -8), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timer)
		{
			Instantiate (enemyPrefab[0], new Vector3 (-17, 0.5f, -8), Quaternion.identity);
			timer = Time.time + enemyCreationTime;
		}
	}
}
