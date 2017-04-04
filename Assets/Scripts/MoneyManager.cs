using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float balance = 100;
    public GameObject towerPrefab;

	// Use this for initialization
	void Start ()
    {
        Instantiate(towerPrefab, new Vector3(0, 0, -4), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
